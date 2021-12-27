using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTimer : MonoBehaviour
{
    // Start is called before the first frame update
    public float timePlusVel;
    private TMPro.TextMeshProUGUI textMesh;
    private int Timer = 30;
    private float timer = 0;
    private Animator animator;
    public static UiTimer Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        animator = GetComponentInChildren<Animator>();
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f)
        {
            if(Timer == 1)
            {
                Time.timeScale = 0f;
                ResetScreen.Instance.gameEnd = true;
                ResetScreen.Instance.Show();
            }
            Timer--;
            timer = 0;
        }
            
        textMesh.text = Timer.ToString();
    }

    public void MoreTime()
    {
        Timer += 5;
        animator.SetTrigger("MoreTime");
    }
}
