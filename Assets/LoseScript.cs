using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LoseScript : MonoBehaviour
{
    public GameObject player;

    bool losePlaying;

    public PlayableDirector cinematicDirector;
    public PlayableAsset lose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 10f && !losePlaying)
        {
            cinematicDirector.Play(lose);
            losePlaying = true;
        }
    }
}
