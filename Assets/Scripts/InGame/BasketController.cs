using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{   
    private GameController gameController;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Ball")
        {
            gameObject.GetComponentInChildren<Animator>().SetTrigger("Score");
            
            UiScore.Instance.IncreaseScore();
            UiTotalScore.Instance.IncreaseTotalScore();
            
            GameController.Instance.SpawnBasket(other.transform.position);
            GameController.Instance.SpawnBall();
            

            Destroy(gameObject,0.3f);
            Destroy(other.gameObject);
        }

    }
}
