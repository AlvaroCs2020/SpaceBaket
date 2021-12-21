using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{   
    private GameController gameController;
    private void OnTriggerEnter(Collider other) 
    {
        gameObject.GetComponentInChildren<Animator>().SetTrigger("Score");
        
        UiScore.Instance.IncreaseScore();
        UiTotalScore.Instance.IncreaseTotalScore();
        
        Destroy(gameObject,0.3f);
        Destroy(other.gameObject,0.5f);
        
        GameController.Instance.SpawnBall();
        GameController.Instance.SpawnBasket();
    }
}