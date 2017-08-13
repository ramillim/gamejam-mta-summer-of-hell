using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandlordPhrases : MonoBehaviour {

    Coroutine activeTimerCoroutine;

    float minTime = 0.5f;
    float maxTime = 2.0f;

    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        activeTimerCoroutine = StartCoroutine (RandomTimer(minTime, maxTime));

        //To Stop the coroutine:
        //StopCoroutine(activeTimerCoroutine);
    }

    IEnumerator RandomTimer(float minTime, float maxTime)
    {
        //WARNING: This will loop forever until the coroutine is stopped.
        int index = Random.Range(0, shoot.Length);
        while (true) {
            yield return new WaitForSeconds (Random.Range (minTime, maxTime));
            if (audioSource.isPlaying)
                continue;
            shootClip = shoot[index];
            audioSource.clip = shootClip;
            audioSource.Play();
            index = Random.Range(0, shoot.Length);
        }
    }
}
