using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState
{
    Intro,
    Playing,
    Paused,
    GameOver
}

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event OnStateChangeHandler OnStateChange;

    [SerializeField]
    private GameState currentState;

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    public void SetState(GameState state)
    {
        CurrentState = state;
        OnStateChange();
    }
}
