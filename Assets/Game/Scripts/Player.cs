using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region References
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private CharacterController characterController;
    private CharacterController controller;
    [SerializeField] private Slider slider;
    [SerializeField] private Transform camera;
    #endregion

    #region Score
    [SerializeField] private Text textScore;
    [SerializeField] private Text textGoal;
    private int myScore, otherScore;
    private float goalTextColorAlpha;
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

    private float shootButtonDownTime = 0;
    private float shootHoldDuration = 0;
    private float additionalTime = 0;
    private float maxHoldTime = 3f;

    [SerializeField] private float shootMultiplier = 2f;


    #endregion
    // Start is called before the first frame update
    void Start()
    {

        characterController = GetComponent<CharacterController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }


    private void LateUpdate()
    {
        slider.transform.LookAt(camera.position);
    }
    // Update is called once per frame
    void Update()
    {
        float speed = new Vector3(characterController.velocity.x, 0, characterController.velocity.z).magnitude;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            shootButtonDownTime = Time.time;
        }

        if (Input.GetKey(KeyCode.Return))
        {
            // Calculate how long the button has been held down
            shootHoldDuration = Time.time - shootButtonDownTime;

            slider.value = (float)shootHoldDuration / maxHoldTime;

            if (shootHoldDuration >= maxHoldTime)
            {
                // Release the button to simulate player releasing it
                Input.GetKeyUp(KeyCode.Return);
            }
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            slider.value = 0f;
            shootHoldDuration = Mathf.Min(shootHoldDuration, maxHoldTime); // Clamp the hold duration to the max hold time
            additionalTime = shootHoldDuration;
            Debug.Log(shootHoldDuration.ToString("F2"));

            starterAssetsInputs.shoot = false;
            timeShot = Time.time;
            animator.Play("Shoot", LAYER_SHOOT, 0f);
            animator.SetLayerWeight(LAYER_SHOOT, 1f);
        }
        if (timeShot > 0)
        {
            // shoot ball
            if (ballAttachedToPlayer != null && Time.time - timeShot > 0.2)
            {
                soundKick.Play();
                ballAttachedToPlayer.StickToPlayer = false;

                Rigidbody rigidbody = ballAttachedToPlayer.transform.gameObject.GetComponent<Rigidbody>();
                Vector3 shootdirection = transform.forward;
                shootdirection.y += 0.3f;
                Debug.Log(additionalTime);
                rigidbody.AddForce(shootdirection * shootPower * shootMultiplier * additionalTime, ForceMode.Impulse);
                ballAttachedToPlayer = null;
            }
            // finished kicking animation
            if (Time.time - timeShot > 0.5)
            {
                timeShot = 0;
            }
        }
        else
        {
            animator.SetLayerWeight(LAYER_SHOOT, Mathf.Lerp(animator.GetLayerWeight(LAYER_SHOOT), 0f, Time.deltaTime * 10f));
        }

        if (goalTextColorAlpha > 0)
        {
            goalTextColorAlpha -= Time.deltaTime;
            // textGoal.alpha = goalTextColorAlpha;
            //textGoal.fontSize = 200 - (goalTextColorAlpha * 120);
        }

        if (ballAttachedToPlayer != null)
        {
            distanceSinceLastDribble += speed * Time.deltaTime;
            if (distanceSinceLastDribble > 3)
            {

                distanceSinceLastDribble = 0;
            }
        }
    }

    public void IncreaseMyScore()
    {
        myScore++;
        UpdateScore();
    }
    public void IncreaseOtherScore()
    {
        otherScore++;
        UpdateScore();
    }

    private void UpdateScore()
    {
        soundCheer.Play();
        textScore.text = "Score: " + myScore + "-" + otherScore;
    }


}