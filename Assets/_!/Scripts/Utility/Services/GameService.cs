using System;
using UnityEngine;

public class GameService : MonoBehaviour, IService
{
    private GameStates _currentGameState;
    public GameStates CurrentGameState
    {
        get => _currentGameState;
        private set
        {
            _currentGameState = value;
            ActionHandler<GameStates>.Raise(ActionKey.GameStateChangeKey, _currentGameState);
            Debug.Log($"<color=green> New game state: {_currentGameState}</color>");
        }
    }

    private void Awake()
    {
        ServiceProvider.Register(this);
        ActionHandler.Register(ActionKey.CompleteGameKey, CompleteState);
    }

    private void OnDestroy()
    {
        ServiceProvider.Unregister<GameService>();
        ActionHandler.Unregister(ActionKey.CompleteGameKey, CompleteState);
    }

    public void SetNewGameState(GameStates newGameState)
    {
        switch (newGameState)
        {
            case GameStates.Gameplay: GameplayState(); break;
            case GameStates.Complete: CompleteState(); break;
            case GameStates.Fail: FailState(); break;
            default: throw new ArgumentOutOfRangeException(nameof(newGameState), newGameState, null);
        }
    }

    private void GameplayState()
    {
        if (_currentGameState == GameStates.Gameplay)
        {
            Debug.LogWarning($"current game state is already {_currentGameState}!");
            return;
        }

        CurrentGameState = GameStates.Gameplay;
    }

    private void CompleteState()
    {
        if (_currentGameState is GameStates.Complete or GameStates.Fail)
        {
            Debug.LogWarning($"your current game state is {_currentGameState} and you are trying to change it multiple times!");
            return;
        }

        DataHandler.LevelIndex++;
        CurrentGameState = GameStates.Complete;
    }

    private void FailState()
    {
        if (_currentGameState == GameStates.Complete || _currentGameState == GameStates.Fail)
        {
            Debug.LogWarning($"your current game state is {_currentGameState} and you are trying to change it multiple times!");
            return;
        }

        CurrentGameState = GameStates.Fail;
    }
}