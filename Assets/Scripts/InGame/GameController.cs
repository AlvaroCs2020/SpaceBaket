using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject Basket;

    public static GameController Instance;
    private void Start() 
    {
        Time.timeScale = 1;
        Instance = this;
    }
    private void Update() {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 9f);
    }
    public void SpawnBall()
    {   
        if(GameObject.FindGameObjectsWithTag("Ball").Length == 1)
            Instantiate(Ball,startPoint.position,Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
    }
    public void SpawnBasket(Vector3 otherHoop)
    {

        float x =Random.Range(-30.0f, 30.0f);
        float y =Random.Range(-12.0f, 2f);
        float z =Random.Range(3f, 14f);
        while(Vector3.Distance(new Vector3(otherHoop.x,0f,otherHoop.z),new Vector3(x,0f,z)) < 8f )
        {
            x =Random.Range(-30.0f, 30.0f);
            y =Random.Range(-12.0f, 2f);
            z =Random.Range(3f, 14f);
        }
        if(GameObject.FindGameObjectsWithTag("Basket").Length <= 1)
            Instantiate(Basket,new Vector3(x,y,z),Quaternion.Euler(-90, x/30*50 , 0 ));
    }
}
