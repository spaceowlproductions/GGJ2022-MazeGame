using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LoseScript : MonoBehaviour
{
    public GameObject player;

    bool losePlaying;

    PlayableDirector cinematicDirector;
    PlayableAsset lose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 5 && !losePlaying)
        {
            cinematicDirector.Play(lose);
            losePlaying = true;
        }
    }
}
