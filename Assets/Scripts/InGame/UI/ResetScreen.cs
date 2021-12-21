using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScreen : MonoBehaviour
{
    public static ResetScreen Instance;
    private RectTransform rectTransform;
    private TMPro.TextMeshProUGUI highScoreText;
    private bool paused = false;
    void Start()
    {
        Instance = this;

        rectTransform = GetComponent<RectTransform>();
        highScoreText = GetComponentInChildren<TMPro.TextMeshProUGUI>();

        Hide();
    }
    public void Pause()
    {
        if (paused)
        {
            Hide();
            Time.timeScale = 1f;
        }
        else
        {
            Show();
            Time.timeScale = 0f;
        }
        paused = !paused; 
    }
    public void Hide()
    {
        rectTransform.localScale = new Vector3(0,0,0);
    }
    public void Show()
    {
        highScoreText.text = "High Score = " + PlayerPrefs.GetInt("highScore", 0).ToString();
        rectTransform.localScale = new Vector3(0.01f,0.01f,0.01f);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
