using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

    private List<PointInTime> pointsInTime;
    private bool isRewinding;
    private float maxRewindTime = 10f;
    private GameObject origin;
    private LineRenderer lineRenderer;
    public static int numPoints = 50;
    public bool drawLine = true;

    Rigidbody rb;
    void Start(){
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.endColor = Color.white;
        lineRenderer.startColor = Color.cyan;
    }

    void FixedUpdate ()
    {
        if (isRewinding)
            Rewind();
        else
            Record();
	}

    void Record()
    {
        if (pointsInTime.Count > Mathf.Round(maxRewindTime * 1f / Time.fixedDeltaTime))
        {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }
        pointsInTime.Insert(0, new PointInTime(transform));
    }

    void Rewind()
    {
        if (pointsInTime.Count > 0)
        {
            PointInTime pit = pointsInTime[0];
            transform.position = pit.position;
            transform.rotation = pit.rotation;
            pointsInTime.Remove(pointsInTime[0]);
            if (drawLine)
            {
                Vector3 p0 = origin.transform.position;
                Vector3 p1 = transform.position;
                DrawQuadraticCurve(p0, p1, p0 + origin.transform.forward.normalized * Vector3.Distance(p0, p1) * 3 / 4);
            }
        }
        else
        {
            StopRewind();
        }
    }

    public void StartRewind(GameObject _origin)
    {
        origin = _origin;
        lineRenderer.positionCount = numPoints;
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        lineRenderer.positionCount = 1;
        lineRenderer.SetPositions(new Vector3[] { new Vector3(0, 0, 0) });
        isRewinding = false;
        rb.isKinematic = false;
    }
    public bool canRewind()
    {
        return pointsInTime.Count > 0;
    }

    
    private void DrawQuadraticCurve(Vector3 p0, Vector3 p1, Vector3 p2)
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numPoints;
        Vector3[] positions = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float t = i / ((float)numPoints);
            positions[i] = CalculateQuadraticPoint(t, p0, p1, p2);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateQuadraticPoint(float t, Vector3 p0, Vector3 p2, Vector3 p1)
    {
        float oneminust = 1 - t;
        Vector3 ret = oneminust * oneminust * p0 + 2 * oneminust * t * p1 + t * t * p2;
        return ret;
    }
}
