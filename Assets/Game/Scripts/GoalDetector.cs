using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GoalDetector : MonoBehaviour
{
    [SerializeField] private Player scriptPlayer;
    [SerializeField] private GameObject goalText;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform ballStartLocation;
    [SerializeField] private Transform playerStartLocation;

    void Start()
    {
        goalText.SetActive(false);
    }
    IEnumerator ToggleShowGoalText(int second)
    {
        goalText.SetActive(true);
        yield return new WaitForSeconds(second);
        goalText.SetActive(false);

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            if (name.Equals("GoalDetector1"))
            {
                scriptPlayer.IncreaseMyScore();

            }
            else
            {
                scriptPlayer.IncreaseOtherScore();

            }
            StartCoroutine(ToggleShowGoalText(2));
            player.transform.DOMove(playerStartLocation.position,0.1f);
            ball.transform.DOMove(ballStartLocation.position,0.1f);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.velocity = rb.velocity.normalized * 0f;
        }
    }
}