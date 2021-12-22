using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TextMeshProUGUI textMesh;
    private int Timer = 60;
    private float timer = 0;

    public static UiTotalScore Instance;
    // Start is called before the first frame update
    void Start()
    {
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
}
