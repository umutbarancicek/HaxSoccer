using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    [SerializeField] private Player scriptPlayer;
    [SerializeField] private GameObject goalText;


  void Start(){
    goalText.SetActive(false);
  }



   IEnumerator ToggleShowGoalText(int second){
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

            
        }
    }
}