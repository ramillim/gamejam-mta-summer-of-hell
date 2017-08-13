using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string nextScene;

    GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
        gm.OnStateChange += HandleOnStateChange;
    }

    private void Start()
    {
        gm.SetState(GameState.Playing);
    }

    private void HandleOnStateChange()
    {
        Invoke("LoadNextScene", 5f);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(nextScene);
    }
}
