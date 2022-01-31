using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class EnemyFootsteps : MonoBehaviour
{
    public Animator anim;

    public void Footstep()
    {
        RuntimeManager.PlayOneShotAttached("event:/Enemy Sounds/enemyFootsteps", gameObject);
        anim.SetTrigger("Pulse");
    }

}
