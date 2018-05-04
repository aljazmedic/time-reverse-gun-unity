using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookGunScript : MonoBehaviour {

    public GameObject hook;
    public Transform origin;
    public float hookSpeed;
    public bool hooked;
    public bool flying;
    public float speedOfReel;
    private GameObject firstparent;

    public float maxDistance;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            flying = true;
            //hook.GetComponent<Rigidbody>().isKinematic = true;
            firstparent = hook.transform.parent.gameObject;
            hook.transform.parent = null;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ReturnHook();
           // hook.GetComponent<Rigidbody>().isKinematic = false;
        }
}

    public void ReturnHook()
    {
        hook.transform.position = origin.position;
        hook.transform.rotation = origin.rotation;
        flying = false;
        hooked = false;
        hook.transform.parent = firstparent.transform;
    }
}
