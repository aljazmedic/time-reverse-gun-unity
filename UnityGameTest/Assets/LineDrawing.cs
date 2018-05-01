using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour {

    public LineRenderer lineRenderer;

    private int numPoints = 50;
    private Vector3[] positions;
    public Transform p0, p1, p2;
    void Start()
    {
        positions = new Vector3[numPoints];
        lineRenderer.positionCount = numPoints;
        
    }
    void Update()
    {
        DrawQuadraticCurve(p0, p1, p2);
    }
    public void DrawQuadraticCurve(Transform p0, Transform p1, Transform p2)
    {
    
        for (int i = 0; i < numPoints; i++)
        {
            float t = i / ((float)numPoints);
            positions[i] = CalculateQuadraticPoint(t, p0.position, p1.position, p2.position);
        }
        lineRenderer.SetPositions(positions);
    }

    private Vector3 CalculateQuadraticPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float oneminust = 1 - t;
        Vector3 ret = oneminust * oneminust * p0 + 2 * oneminust * t * p1 + t * t * p2;
        return ret;
    }
}
