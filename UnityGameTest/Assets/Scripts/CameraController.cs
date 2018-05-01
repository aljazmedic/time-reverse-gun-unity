using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;
    [Range(0.01f, 1f)]
    public float smoothSpeed = 0.125f;
    private bool rotateAroundPlayer = false;
    public float rotationSpeed = 5.0f;
    private Quaternion camTurnAngle;
    private Vector3 offset;
    private Quaternion targetLastRotation;


	// Use this for initialization
	void Start () {
        offset = transform.position - target.transform.position;
        targetLastRotation = target.transform.rotation;
	}
    
	// Update is called once per frame
	void LateUpdate () {
        rotateAroundPlayer = targetLastRotation == target.transform.rotation;

        if (!rotateAroundPlayer)
        {
            camTurnAngle =
                Quaternion.AngleAxis((target.transform.rotation.eulerAngles.y - targetLastRotation.eulerAngles.y), Vector3.up);
        }
        else
        {
            camTurnAngle =
                   Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
       }
       offset = camTurnAngle * offset;

        Vector3 desired = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Slerp(transform.position, desired, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target.transform
            .GetComponent<PlayerController>().getOffsetLook());

        targetLastRotation = target.transform.rotation;
	}
}
