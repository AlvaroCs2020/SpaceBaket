using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{   
    [SerializeField] private float forceMultiplier = 15;

    private AudioSource audioSource;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(0.90f,1.1f);
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }
    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition-mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x,forceInit.y,forceInit.y)) * forceMultiplier;
        Vector3 fixedPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z );
        mouseReleasePos = Input.mousePosition;
        if(!isShoot)
            DrawTrajectory.Instance.UpdateTrajectory(forceV,rb,fixedPosition);
    }
    private void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        if(Vector3.Distance(mouseReleasePos,mousePressDownPos) > 15f)
            Shoot(mouseReleasePos-mousePressDownPos);
        
    }

    
    void Shoot(Vector3 Force)
    {   
        if(isShoot)    
            return;
        if(Force.y<0)
            forceMultiplier = -forceMultiplier;
        
        audioSource.Play();
        rb.AddForce(new Vector3(Force.x,Force.y,Force.y)* forceMultiplier);
        isShoot = true;
    }
    
}