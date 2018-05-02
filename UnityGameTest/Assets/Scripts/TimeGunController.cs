using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGunController : MonoBehaviour {

    private TimeBody target;
    public GameObject origin;
    public float maxDistance = 100f;
    private int numPoints = 50;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, maxDistance))
            {
                Debug.DrawRay(hit.point,origin.transform.forward, Color.red, 2, false);
                target = hit.transform.GetComponent<TimeBody>();
                if (target != null && target.canRewind())
                {
                    target.StartRewind(origin);
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (target != null)
            {
                target.StopRewind();
            }
        }
	}
}
