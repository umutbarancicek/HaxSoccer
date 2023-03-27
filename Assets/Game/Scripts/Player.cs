
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private StarterAssetsInputs starterAssetsInputs;
    private Ball ballAttachedToPlayer;
    private Animator animator;
    private float timeShot;
    public const int ANIMATION_LAYER_SHOOT = 1;

    public Ball BallAttachedToPlayer { get => ballAttachedToPlayer; set => ballAttachedToPlayer = value; }

    void Start()
    {
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Shoot button pressed");
            starterAssetsInputs.shoot = true;
        }

        if (starterAssetsInputs.shoot)
        {
            Debug.Log("starterAssetsInputs.shoot");
            starterAssetsInputs.shoot = false;
            timeShot = Time.time;

            animator.Play("Shoot", ANIMATION_LAYER_SHOOT, 0f);
            animator.SetLayerWeight(ANIMATION_LAYER_SHOOT, 1f);
        }

        if (timeShot > 0)
        {
            
            if (ballAttachedToPlayer)
            {
                ballAttachedToPlayer.stickToPlayer = false;

                Rigidbody rigidbody = ballAttachedToPlayer.transform.gameObject.GetComponent<Rigidbody>();    
                rigidbody.AddForce(transform.forward * 20f, ForceMode.Impulse);

                ballAttachedToPlayer = null;
            }

            if (Time.time - timeShot > 0.5)
            {
                timeShot = -1f;
            }
        }
        else
        {
            animator.SetLayerWeight(ANIMATION_LAYER_SHOOT, Mathf.Lerp(animator.GetLayerWeight(ANIMATION_LAYER_SHOOT), 0f, Time.deltaTime * 10f));
        }

    }
}

/**using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private StarterAssetsInputs starterAssetsInputs;
    private Ball ballAttachedToPlayer;
    private Animator animator;
    private float timeShot;
    public const int ANIMATION_LAYER_SHOOT = 1;

    public Ball BallAttachedToPlayer { get => ballAttachedToPlayer; set => ballAttachedToPlayer = value; }
    // Start is called before the first frame update
    void Start()
    {
    starterAssetsInputs = GetComponent<StarterAssetsInputs>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if (starterAssetsInputs.shoot)
        {
            Debug.Log("starterAssetsInputs.shoot");
            starterAssetsInputs.shoot = false;
            timeShot = Time.time;
            
            animator.Play("Shoot", ANIMATION_LAYER_SHOOT, 0f);
            animator.SetLayerWeight(ANIMATION_LAYER_SHOOT, 1f);
        }
        if (timeShot > 0)
        {
            // shoot ball
            if(ballAttachedToPlayer != null && Time.time - timeShot > 0.2)
            {

                ballAttachedToPlayer.stickToPlayer = false;
                Rigidbody rigidbody = ballAttachedToPlayer.transform.gameObject.GetComponent<Rigidbody>();
                Debug.Log(rigidbody);
                rigidbody.AddForce(transform.forward * 20f, ForceMode.Impulse);
                ballAttachedToPlayer = null;
            }

            // finished kicking animation
            if(Time.time - timeShot > 0.5)
            {
                timeShot = -1f;
            }
        }
        else
        {
            //TODO: stop animation
            animator.SetLayerWeight(ANIMATION_LAYER_SHOOT, Mathf.Lerp(animator.GetLayerWeight(ANIMATION_LAYER_SHOOT), 0f, Time.deltaTime * 10f));
        }
        
    }
}*/





