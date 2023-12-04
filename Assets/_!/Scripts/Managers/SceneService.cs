using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : MonoBehaviour, IService
{
    private CancellationTokenSource _cancellationTokenSource;
    private AsyncOperation _asyncOperation = new AsyncOperation();
    private const string GameSceneName = "GameScene";
    private const string MainSceneName = "MainScene";
    
    private void Awake()
    {
        ServiceProvider.Register(this);
        //EventHandler.OnGameStateChanged += OnGameStateChanged;
        ActionHandler<GameStates>.Register(ActionKey.GameStateChangeKey ,OnGameStateChanged);
        _cancellationTokenSource = new CancellationTokenSource();
        
        HandleFirstLoad();
    }

    private void OnDestroy()
    {
        ServiceProvider.Unregister<SceneService>();
        //EventHandler.OnGameStateChanged -= OnGameStateChanged;
        ActionHandler<GameStates>.Unregister(ActionKey.GameStateChangeKey ,OnGameStateChanged);
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }

    private async void OnGameStateChanged(GameStates newGameState)
    {
        switch (newGameState)
        {
            case GameStates.Gameplay:
                break;
            case GameStates.Complete:
                await LoadGameScene(.5f);
                break;
            case GameStates.Fail:
                await LoadGameScene(.5f);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newGameState), newGameState, null);
        }
    }

    private async void HandleFirstLoad()
    {
        await LoadSceneAsync(GameSceneName); 
    }

    private async UniTask LoadGameScene(float delay = 0)
    {
        try
        {
            await UnloadSceneAsync(SceneManager.GetActiveScene().name);
            await UniTask.Delay(TimeSpan.FromSeconds(delay), cancellationToken:_cancellationTokenSource.Token);
            await LoadSceneAsync(GameSceneName);
            ServiceProvider.GetService<GameManager>().SetNewGameState(GameStates.Gameplay);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }
    
    private async UniTask LoadSceneAsync(string sceneToLoadName)
    {
        try
        {
            _asyncOperation = SceneManager.LoadSceneAsync(sceneToLoadName, LoadSceneMode.Additive);
            _asyncOperation.allowSceneActivation = true;

            await _asyncOperation.WithCancellation(_cancellationTokenSource.Token);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToLoadName));
            
            Debug.Log($"Scene load is successfully completed, active scene name: {sceneToLoadName}");
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }

    private async UniTask UnloadSceneAsync(string sceneToUnloadName)
    {
        try
        {
            _asyncOperation = SceneManager.UnloadSceneAsync(sceneToUnloadName);

            await _asyncOperation.WithCancellation(_cancellationTokenSource.Token);
            
            Debug.Log($"Scene unload is successfully completed, unload scene name: {sceneToUnloadName}");
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }
}
