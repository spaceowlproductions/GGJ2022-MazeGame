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

    public enum HeroState { Thinking, Walking, Running };
    public HeroState heroState;

    public float runEnergy;

    public GameObject player;

    public float fearDistance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < fearDistance)
        {
            if (heroState != HeroState.Running)
                Run();
        }
    }

    IEnumerator RunEnergy()
    {        
        float totalTime = 0;
        while (totalTime <= runEnergy)
        {
            totalTime += Time.deltaTime;
            yield return null;
        }
        yield break;
    }

    public void Run()
    {
        agent.speed = runSpeed;

        if (heroState == HeroState.Thinking)
            agent.isStopped = false;

        heroState = HeroState.Running;
    }

    public void Walk ()
    {
        agent.speed = walkSpeed;

        if (heroState == HeroState.Thinking)
            agent.isStopped = false;

        heroState = HeroState.Walking;
    }


}
