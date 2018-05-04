using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookScript : MonoBehaviour {

    public GameObject gun;
    public GameObject player;
    private HookGunScript hgs;
    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
        hgs = gun.GetComponent<HookGunScript>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (hgs.flying && !hgs.hooked)
        {
            if (Vector3.Distance(transform.position, hgs.origin.position) >= hgs.maxDistance)
            {
                hgs.ReturnHook();
                return;
            }
            transform.Translate(Vector3.forward.normalized * hgs.hookSpeed * Time.fixedDeltaTime);
        }
        else if (hgs.hooked)
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= 5)
            {
                hgs.ReturnHook();
                return;
            }
            player.transform.position = Vector3.MoveTowards(player.transform.position, transform.position, Time.fixedDeltaTime * hgs.speedOfReel);
        }
        if (hgs.hooked || hgs.flying)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPositions(new Vector3[] {hgs.origin.position, transform.position });
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hook hit");
        hgs.flying = false;
        hgs.hooked = true;
    }
}
