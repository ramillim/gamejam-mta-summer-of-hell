using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public AudioClip hitSound;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            audioSource.PlayOneShot(hitSound);
            Destroy(gameObject, 1f);
        }
    }
}
