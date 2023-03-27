/**using System.Collections;
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
public float hitForce = 1000f;
private Rigidbody ballRigidbody;

public bool StickToPlayer { get => stickToPlayer; set => stickToPlayer = value; }



    void Start()
    {
        

       
         playerBallPosition = transformPlayer.Find("Geometry").Find("BallPosition");
         scriptPlayer = transformPlayer.GetComponent<Player>();
        // Debug.Log("Ball position");
        //  Debug.Log(scriptPlayer.BallAttachedToPlayer);
        /**Transform ballTransform = transformPlayer.Find("Ball");
        if (ballTransform != null)
        {
            Vector3 ballPosition = ballTransform.position;
            Debug.Log("Ball position: " + ballPosition);
        
        }
        else
        {
            Debug.Log("Ball not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
  
    if((!stickToPlayer)) 
        {
            float distanceToPlayer = Vector3.Distance(transformPlayer.position, transformPlayer.position);
            if(distanceToPlayer < 0.5) 
            {
                StickToPlayer = true;
                scriptPlayer.BallAttachedToPlayer = this;
            }
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
    




}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Transform playerBallPosition;
    public Player scriptPlayer;
    public bool stickToPlayer;
    private float speed;
    private Vector3 previousLocation;
    private Rigidbody ballRigidbody;
    public float hitForce = 1000f;

    void Start()
    {
        Transform ballTransform = transformPlayer.Find("Ball");
        if (ballTransform != null)
        {
            Vector3 ballPosition = ballTransform.position;
            Debug.Log("Ball position: " + ballPosition);
        }
        else
        {
            Debug.Log("Ball not found!");
        }

        ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = true;
    }

    void Update()
    {
        if (!stickToPlayer)
        {
            CheckDistance();
        }
        else
        {
            MoveWithBall();
        }

        // Shoot the ball when X is pressed
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootBall();
            scriptPlayer.BallAttachedToPlayer = null;
            stickToPlayer = false;
            ballRigidbody.AddForce(transform.forward * 20f, ForceMode.Impulse);
        }
    }

    void CheckDistance()
    {
        float distanceToPlayer = Vector3.Distance(transformPlayer.position, transform.position);
        if (distanceToPlayer < 0.5)
        {
            stickToPlayer = true;
            scriptPlayer.BallAttachedToPlayer = this;
        }
    }

    void MoveWithBall()
    {
        Vector2 currentLocation = new Vector2(transform.position.x, transform.position.y);
        speed = Vector2.Distance(currentLocation, previousLocation) / Time.deltaTime;
        transform.position = playerBallPosition.position;
        transform.Rotate(new Vector3(transformPlayer.right.x, 0, transformPlayer.right.z), speed, Space.World);
        previousLocation = currentLocation;
    }
    void ShootBall()
    {
        
        ballRigidbody.isKinematic = false;
        ballRigidbody.AddForce(transformPlayer.forward * hitForce);
        
    }


}




