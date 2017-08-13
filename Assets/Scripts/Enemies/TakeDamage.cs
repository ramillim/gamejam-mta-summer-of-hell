using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioSource audioSource;
    public float forceMultiplier = 1000f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            audioSource.PlayOneShot(hitSound);
            Vector3 collisionVector = (transform.position - collision.transform.position).normalized;
            rb.AddForce(collisionVector * forceMultiplier);
            Destroy(gameObject, 1f);
        }
    }
}
