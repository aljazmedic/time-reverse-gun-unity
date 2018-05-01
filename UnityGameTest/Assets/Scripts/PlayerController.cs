using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float XSpeed;
    public float rotationSpeed;
    public Transform offsetLook;
	// Use this for initialization
	void Start () {
        //speed = GetComponent<UnityEngine.AI.NavMeshAgent>().speed;
	}
	
	// Update is called once per frame
	void Update () {
        float translationX = Input.GetAxis("Vertical") * XSpeed;
        float translationY = Input.GetAxis("Horizontal") * 0.5f * XSpeed;
        float rotation = Input.GetAxis("Mouse X") * rotationSpeed;
        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(translationY, 0, translationX);
        transform.Rotate(0, rotation, 0);
	}

    public Transform getOffsetLook()
    {
        return offsetLook;
    }
}
