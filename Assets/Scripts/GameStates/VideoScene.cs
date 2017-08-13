using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoScene : MonoBehaviour {
    public string nextScene;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}
