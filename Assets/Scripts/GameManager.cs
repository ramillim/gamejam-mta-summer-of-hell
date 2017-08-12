using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Intro,
    Playing,
    Paused,
    GameOver
}

public delegate void OnStateChangeHandler();

public class GameManager : Singleton<GameManager>
{
    public event OnStateChangeHandler OnStateChange;

    [SerializeField]
    private GameState currentState;

    public GameState CurrentState { get; private set; }

    public void SetState(GameState state)
    {
        CurrentState = state;
        OnStateChange();
    }
}
