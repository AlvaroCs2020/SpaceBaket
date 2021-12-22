using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudio : MonoBehaviour
{
    private void Awake() 
    {
        if(GameObject.FindGameObjectsWithTag("Music").Length == 1)
        {
            DontDestroyOnLoad(gameObject);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
