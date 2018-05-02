using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawing : MonoBehaviour {

    public static int numPoints = 50;

    public void DrawQuadraticCurve(Vector3 p0, Vector3 p1, Vector3 p2)
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

    private Vector3 CalculateQuadraticPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float oneminust = 1 - t;
        Vector3 ret = oneminust * oneminust * p0 + 2 * oneminust * t * p1 + t * t * p2;
        return ret;
    }
}
