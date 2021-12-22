using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiScore : MonoBehaviour
{
    private TMPro.TextMeshProUGUI textMesh;
    public int Score = 0;

    public static UiScore Instance;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TMPro.TextMeshProUGUI>();
        Instance = this;
    }

    public void ResetScore()
    {
        Score = 0;
        textMesh.text = "x" + Score.ToString();
    }
    public void IncreaseScore()
    {
        Score++;
        textMesh.text = "x" + Score.ToString();
    }

    
}
