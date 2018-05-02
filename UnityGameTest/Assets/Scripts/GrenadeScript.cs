using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    public GameObject explosionEffect;
    public float radius = 5f;
    public float force = 700f;
    public float delay = 3f;
    float countdown;
	// Use this for initialization
    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            Explode();
        }
    }

	// Update is called once per frame
    void Explode()
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
            Destroy(gameObject);
            Destroy(expl, time);
    }
}
