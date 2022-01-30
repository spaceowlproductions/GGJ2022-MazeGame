using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class WalkSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Step()
    {
        RuntimeManager.PlayOneShot("event:/Player Footsteps/playerFootsteps");
    }
}
