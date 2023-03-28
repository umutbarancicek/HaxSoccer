using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region References
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private CharacterController characterController;
    private CharacterController controller;
    #endregion

    #region Text Mesh Pro

    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textGoal;
    #endregion

    #region Audio Sources
     [SerializeField] private AudioSource soundCheer;
     [SerializeField] private AudioSource soundKick;
    #endregion

    #region Ball
    private Ball ballAttachedToPlayer;
    public Ball BallAttachedToPlayer { get => ballAttachedToPlayer; set => ballAttachedToPlayer = value; }
    #endregion
    
    #region Variables
    [SerializeField] private float shootPower;
    private float timeShot;
    private const int LAYER_SHOOT = 1;
    private float distanceSinceLastDribble;
    private float goalTextColorAlpha;
    private int myScore, otherScore; 
    #endregion
    // Start is called before the first frame update
    void Start()
    {
      
        characterController = GetComponent<CharacterController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        soundCheer = GameObject.Find("Sound/cheer").GetComponent<AudioSource>();  //b
        soundKick = GameObject.Find("Sound/kick").GetComponent<AudioSource>();    //b
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
        float speed = new Vector3(characterController.velocity.x, 0, characterController.velocity.z).magnitude;
        if (starterAssetsInputs.shoot)
        {
            starterAssetsInputs.shoot = false;
            timeShot = Time.time;
            animator.Play("Shoot", LAYER_SHOOT, 0f);
            animator.SetLayerWeight(LAYER_SHOOT, 1f);
        }
        if (timeShot > 0)
        {
            // shoot ball
            if( ballAttachedToPlayer != null && Time.time - timeShot > 0.2)
            {
                
                soundKick.Play();
                ballAttachedToPlayer.StickToPlayer = false;

                Rigidbody rigidbody = ballAttachedToPlayer.transform.gameObject.GetComponent<Rigidbody>();
                Vector3 shootdirection = transform.forward;
                shootdirection.y += 0.3f;
                rigidbody.AddForce(shootdirection * shootPower, ForceMode.Impulse);
                ballAttachedToPlayer = null;
            }

            // finished kicking animation
            if(Time.time - timeShot > 0.5)
            {
                timeShot = 0;
            }
        }
        else
        {
            animator.SetLayerWeight(LAYER_SHOOT, Mathf.Lerp(animator.GetLayerWeight(LAYER_SHOOT), 0f, Time.deltaTime * 10f));
        }

        if (goalTextColorAlpha>0)
        {
            goalTextColorAlpha -= Time.deltaTime;
            textGoal.alpha = goalTextColorAlpha;
            textGoal.fontSize = 200 - (goalTextColorAlpha * 120);
        }

        if (ballAttachedToPlayer!=null)
        {
            distanceSinceLastDribble += speed * Time.deltaTime;
            if (distanceSinceLastDribble > 3)
            {
           
                distanceSinceLastDribble = 0;
            }
        }
    }

    private void UpdateScore()
    {
        soundCheer.Play();
    }

   
}