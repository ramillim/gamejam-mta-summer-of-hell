using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public AudioClip hitSound;

    private void Awake()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = hitSound;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            Destroy(gameObject);
            GetComponent<AudioSource>().Play();
        }
    }
}
