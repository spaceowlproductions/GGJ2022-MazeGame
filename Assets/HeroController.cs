using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;

public class HeroController : MonoBehaviour
{
    private NavMeshAgent agent;  
    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footstep()
    {
        RuntimeManager.PlayOneShotAttached("event:/Enemy Sounds/enemyFootsteps", gameObject);
            
    }
}
