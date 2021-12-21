using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    public float rotationSpeed;
    public float rotationSpeedSky;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeedSky);
        transform.Rotate(new Vector3(rotationSpeed* Time.deltaTime,rotationSpeed* Time.deltaTime,rotationSpeed * Time.deltaTime));
    }
}
