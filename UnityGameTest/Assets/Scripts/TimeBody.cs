using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour {

    private List<PointInTime> pointsInTime;
    private bool isRewinding;
    private float maxRewindTime = 15f;

    Rigidbody rb;
    void Start(){
        if(pointsInTime==null)
            pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
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
        }
        else
        {
            StopRewind();
        }
    }

    public void StartRewind(GameObject origin)
    {
        isRewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
    public bool canRewind()
    {
        return pointsInTime.Count > 0;
    }
}
