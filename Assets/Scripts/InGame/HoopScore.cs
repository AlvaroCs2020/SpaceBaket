using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopScore : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
        audioSource.pitch = Random.Range(0.90f,1.1f);
    }
    public void ScoreSound()
    {
        audioSource.Play();
    }
}
