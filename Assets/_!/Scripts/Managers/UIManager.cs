using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private List<Panel> _panels = new List<Panel>();
    private Panel _currentPanel;
    
    private void Awake()
    {
        ActionHandler<GameStates>.Register(ActionKey.GameStateChangeKey, OnGameStateChanged);
    }

    private void Start()
    {
        HideAllPanels();
        ShowPanel("CompletePanel");
    }

    private void OnDestroy()
    {
        ActionHandler<GameStates>.Unregister(ActionKey.GameStateChangeKey, OnGameStateChanged);
    }

    private void OnGameStateChanged(GameStates newGameStates)
    {
        switch (newGameStates)
        {
            case GameStates.Gameplay: ShowPanel("GameplayPanel"); break;
            case GameStates.Complete: ShowPanel("CompletePanel"); break;
            case GameStates.Fail: ShowPanel("FailPanel"); break;
            default: throw new ArgumentOutOfRangeException(nameof(newGameStates), newGameStates, null);
        }
    }

    private void ShowPanel(string panelId)
    {
        var targetPanel = _panels.FirstOrDefault(p => p.ID == panelId);
        
        if(_currentPanel != null) _currentPanel.Disappear();
        
        targetPanel.Appear();
        _currentPanel = targetPanel;
    }

    private void HideAllPanels()
    {
        foreach (var panel in _panels)
        {
            panel.Disappear();
        }
    }

    public void PlayButtonCallback()
    {
        ServiceProvider.GetService<GameService>().SetNewGameState(GameStates.Gameplay);
        Debug.Log("Button");
    }
    
}
