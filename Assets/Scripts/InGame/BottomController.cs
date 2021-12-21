using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController gameController;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);

            UiScore.Instance.ResetScore();

            if(GameObject.FindGameObjectsWithTag("Ball").Length == 1)
                GameController.Instance.SpawnBall();
        }
    }
}
