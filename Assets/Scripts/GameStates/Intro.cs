using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    GameManager gm;

    private void Awake()
    {
        gm = GameManager.instance;
        gm.OnStateChange += HandleOnStateChange;
    }

    private void HandleOnStateChange()
    {
        gm.SetState(GameState.Playing);
        Invoke("LoadNextScene", 3f);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadSceneAsync("Sandbox");
    }
}
