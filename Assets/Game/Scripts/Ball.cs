using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
private bool stickToPlayer;
private float speed;
private Vector3 previousLocation;

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
        Vector2 currentLocation = new Vector2(transform.position.x,transform.position.y);
        speed = Vector2.Distance(currentLocation,previousLocation) / Time.deltaTime;
        transform.position = playerBallPosition.position;
        transform.Rotate(new Vector3(transformPlayer.right.x,0,transformPlayer.right.z),speed,Space.World);
        previousLocation=currentLocation;
    }

        
    }
}
