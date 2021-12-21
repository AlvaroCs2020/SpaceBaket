using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTotalScore : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TextMeshProUGUI textMesh;
    private int Score = 0;

    private int highScore;
    public static UiTotalScore Instance;
    // Start is called before the first frame update
    void Start()
    {   
        highScore = PlayerPrefs.GetInt("highScore",0);
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        Instance = this;
    }
    public void ResetScore()
    {
        Score = 0;
        textMesh.text =  "score: " + Score.ToString();
    }
    public void IncreaseTotalScore()
    {
        Score += 1 * UiScore.Instance.Score; 
        if (Score > highScore)
        {
            //cambiar el texto de color
            PlayerPrefs.SetInt("highScore", Score);
        }
            
        textMesh.text = (Score <= 9 ? "score: 0":"score: ") + Score.ToString();
    }
}
