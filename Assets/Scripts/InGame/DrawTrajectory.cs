using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    
    [SerializeField] [Range(3,30)] private int _lineSegmentCount = 20;
    [SerializeField] [Range(10,100)] private int _showPercentage = 50;
    [SerializeField] private int _linePointCount;
    [SerializeField] private LineRenderer _lineRenderer;
    private List<Vector3> _linePoints = new List<Vector3>();

    #region Singleton

    public static DrawTrajectory Instance;
    void Start()
    {   
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _linePointCount = (int) (_lineSegmentCount * (_showPercentage /100f));
        Instance = this;
    }
    #endregion

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector/rigidbody.mass) * Time.fixedDeltaTime;

        float flightDuration = ( 2 * velocity.y ) / Physics.gravity.y;

        float stepTime = flightDuration / _lineSegmentCount;

        _linePoints.Clear();

        for (int i = 0; i < _linePointCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 movementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed ,
                velocity.z * stepTimePassed
            );
            //http://hyperphysics.phy-astr.gsu.edu/hbase/traj.html#tracon

            _linePoints.Add(-movementVector + startingPoint);
        }

        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());


    }

    public void HideLine()
    {
        _lineRenderer.positionCount = 0;
    }

}
