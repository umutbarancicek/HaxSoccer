using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
[SerializeField] private Transform transformPlayer; 

// Do not touch this!!!!!!!
[SerializeField] private Transform playerBallPosition; 

public Player scriptPlayer;  
public bool stickToPlayer;
private float speed;
private Vector3 previousLocation;

//public bool StickToPlayer { get => stickToPlayer; set => stickToPlayer = value; }

 

    // Start is called before the first frame update
    void Start()
    {
      scriptPlayer = transformPlayer.GetComponent<Player>();

       //TODO:BUG -  I cant get ball position in here....
      playerBallPosition = transformPlayer.Find("Geometry").Find("BallPosition");
    
       Debug.Log("Ball position");
       Debug.Log(scriptPlayer.BallAttachedToPlayer);
     
    }

    // Update is called once per frame
    void Update()
    {
     playerBallPosition = transformPlayer.Find("Geometry").Find("BallPosition");
    
    if((!stickToPlayer)) {
        CheckDistance();      
    }
    else {
         MoveWithBall();  
    }

        
    }

   void CheckDistance(){
        float distanceToPlayer = Vector3.Distance(transformPlayer.position, transform.position);
        if(distanceToPlayer < 0.5){
        stickToPlayer = true;
        scriptPlayer.BallAttachedToPlayer = this;
        }
    }

   void MoveWithBall(){
        Vector2 currentLocation = new Vector2(transform.position.x,transform.position.y);
        speed = Vector2.Distance(currentLocation,previousLocation) / Time.deltaTime;
        transform.position = playerBallPosition.position;
        transform.Rotate(new Vector3(transformPlayer.right.x,0,transformPlayer.right.z),speed,Space.World);
        previousLocation=currentLocation;
    }




}
