using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;

public class HeroController : MonoBehaviour
{
    private NavMeshAgent agent;  
    public GameObject goal;

    public float runSpeed, walkSpeed;

    public enum HeroState { Thinking, Walking, Running, Tired };
    public HeroState heroState;

    public float runEnergy;
    public float breathPause;
    public float thinkPause;
    public float thinkCountdown;

    public GameObject player;

    public float fearDistance;

    Coroutine running;
    Coroutine thought;

    public Transform[] walkTargets;

    public Animator anim;

    bool runningStarted;

    StudioEventEmitter eventEmitter;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.transform.position);
        eventEmitter = GetComponent<StudioEventEmitter>();

        Think();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < fearDistance)
        {
            if (heroState == HeroState.Thinking || heroState == HeroState.Walking)
            {
                StopAllCoroutines();
                Run();
            }

            float angle = 180;
            if (Vector3.Angle(player.transform.forward, transform.position - player.transform.position) < angle)
            {
                anim.SetBool("Facing", true);
            }
            else
                anim.SetBool("Facing", false);

        }
    }

    IEnumerator RunEnergy()
    {        
        float totalTime = 0;
        float energy = Random.Range(runEnergy, runEnergy + 5);
        while (totalTime <= energy)
        {
            Debug.Log("Energy left = " + (energy - totalTime));
            totalTime += Time.deltaTime;
            yield return null;
        }

        Rest();
        yield break;
    }

    IEnumerator ThinkCountdown()
    {
        float totalTime = 0;
        while (totalTime <= Random.Range(thinkCountdown, thinkCountdown + 5))
        {
            if (heroState == HeroState.Running)
                break;

            totalTime += Time.deltaTime;
            yield return null;
        }

        Think();
        yield break;
    }


    IEnumerator CatchBreath()
    {
        heroState = HeroState.Tired;
        eventEmitter.SetParameter("Running", 0f);
        anim.SetBool("Tired", true);

        float totalTime = 0;
        while (totalTime <= breathPause)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }

        int coinFlip = Random.Range(0, 2);
        if (coinFlip == 0)
            Walk();
        else
            Think();

        anim.SetBool("Tired", false);
        yield break;
    }

    IEnumerator ChangeDirection()
    {
        float totalTime = 0;

        float thinkTime = Random.Range(thinkPause, thinkPause + 3);
        while (totalTime <= thinkTime)
        {
            if (heroState == HeroState.Running)
                break;

            totalTime += Time.deltaTime;
            yield return null;
        }

        int choice = Random.Range(0, walkTargets.Length);
        agent.SetDestination(walkTargets[choice].position);
        Debug.Log("Hero heading toward destination ID: " + choice);
        Walk();
        yield break;
    }


    public void Run()
    {
        Debug.Log("Hero is running!");
        agent.speed = runSpeed;

        if (heroState == HeroState.Thinking)
            agent.isStopped = false;

        heroState = HeroState.Running;

        running = StartCoroutine(RunEnergy());
        anim.SetBool("Moving", true);

        eventEmitter.SetParameter("Running", 1f);
    }

    public void Walk ()
    {
        Debug.Log("Hero has started walking.");
        agent.speed = walkSpeed;

        if (heroState == HeroState.Thinking || heroState == HeroState.Tired)
            agent.isStopped = false;

        heroState = HeroState.Walking;
        anim.SetBool("Moving", true);

        thought = StartCoroutine(ThinkCountdown());
    }

    public void Rest()
    {
        Debug.Log("Hero is tired.");

        agent.isStopped = true;
        if (running != null)
            StopCoroutine(running);

        running = StartCoroutine(CatchBreath());
        anim.SetBool("Moving", false);
    }

    public void Think()
    {
        Debug.Log("Hero is thinking.");
        agent.isStopped = true;

        if (running != null)
            StopCoroutine(running);

        StartCoroutine(ChangeDirection());
        anim.SetBool("Moving", false);
    }


}
