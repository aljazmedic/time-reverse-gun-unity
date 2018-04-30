using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject expl = Instantiate(explosionEffect, transform.position, transform.rotation);
            float time = explosionEffect.GetComponent<ParticleSystem>().duration;
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }
            Destroy(expl, time);
        }
	}
}
