using UnityEngine;



public class GameManager : Singleton<GameManager>
{
    private LevelStates _currentLevelStates = LevelStates.Complete;

    public void SetNewLevelState(LevelStates newLevelStates)
    {
        _currentLevelStates = newLevelStates;
        ActionHandler<LevelStates>.Raise(ActionKey.GameLevelStateChangedKey, _currentLevelStates);
    }
}

