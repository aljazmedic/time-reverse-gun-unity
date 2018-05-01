using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGunController : MonoBehaviour {

    private TimeBody target;
    public GameObject origin;
    public float maxDistance = 100f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Shot");
            RaycastHit hit;
            if (Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, maxDistance))
            {
                Debug.Log("Hit");
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
            Debug.Log("Release");
            if (target != null)
            {
                target.StopRewind();
            }
        }
	}
}
