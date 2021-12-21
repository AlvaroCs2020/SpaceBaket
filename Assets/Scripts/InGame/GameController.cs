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
        Instantiate(Ball,startPoint.position,Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
    }
    public void SpawnBasket()
    {

        float x =Random.Range(-30.0f, 30.0f);
        float y =Random.Range(-12.0f, 2f);
        float z =Random.Range(3f, 14f);
        Instantiate(Basket,new Vector3(x,y,z),Quaternion.Euler(-90, x/30*50 , 0 ));
    }
}
