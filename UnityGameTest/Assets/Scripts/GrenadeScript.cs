using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    private bool exploded;
	// Use this for initialization
    void Start()
    {
        exploded = false;
    }

	// Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (!exploded)
        {
            exploded = true;
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
            Destroy(gameObject);
            Destroy(expl, time);
        }
    }
}
