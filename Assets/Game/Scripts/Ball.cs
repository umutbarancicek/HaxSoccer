using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
private bool stickToPlayer;
[SerializeField] private Transform transformPlayer;
[SerializeField] private Transform playerBallPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    if((!stickToPlayer)) {

       float distanceToPlayer = Vector3.Distance(transformPlayer.position, transform.position);
        if(distanceToPlayer < 0.5){

            stickToPlayer = true;

        }
    }
    else {
        transform.position = playerBallPosition.position;
    }

        
    }
}
