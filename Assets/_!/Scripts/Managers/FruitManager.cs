using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class FruitManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Fruit[] spawnableFruits;
    [SerializeField] private Fruit[] fruitPrefabs;
    [SerializeField] private Transform fruitParent;
    [SerializeField] private LineRenderer fruitSpawnLine;
    private Fruit _currentFruit;

    [Header("Settings")]
    [SerializeField] private float fruitSpawnPositionY;
    [SerializeField] private float spawnDelay = 0.5f;
    private bool canControl;
    private bool isControlling;

    [Header("Next Fruit Settings")]
    private int nextFruitIndex;

    [Header("Debug")]
    [SerializeField] private bool enableGizmos;

    [Header("Actions")]
    public static Action onNextFruitIndexSet;

    #region Unity Methods
    private void Awake()
    {
        MergeManager.onMergeProcessed += MergeProcessedCallback;
        ActionHandler<GameStates>.Register(ActionKey.GameStateChangeKey, EnablePlayerInput);
    }
    private void Start()
    {
        SetNextFruitIndex();

        canControl = false;
        HideLine();
    }

    private void Update()
    {
        if (canControl)
        {
            ManagePlayerInput();
        }
    }

    private void OnDestroy()
    {
        MergeManager.onMergeProcessed -= MergeProcessedCallback;
        ActionHandler<GameStates>.Unregister(ActionKey.GameStateChangeKey, EnablePlayerInput);
    }
    #endregion

    #region Player Input Methods
    private void ManagePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDownCallback();
        }
        else if (Input.GetMouseButton(0))
        {
            if (isControlling)
            {
                MouseDragCallback();
            }
            else
            {
                MouseDownCallback();
            }
        }
        else if (Input.GetMouseButtonUp(0) && isControlling)
        {
            MouseUpCallback();
        }
    }

    private void MouseDownCallback()
    {
        DisplayLine();
        PlaceLineAtClickedPosition();

        SpawnFruit();

        isControlling = true;
    }

    private void MouseDragCallback()
    {
        PlaceLineAtClickedPosition();
        _currentFruit.MoveTo(GetSpawnPosition());
    }

    private void MouseUpCallback()
    {
        HideLine();
        _currentFruit.EnablePhysics();

        canControl = false;
        StartControlTimer();

        isControlling = false;
    }

    private void EnablePlayerInput(GameStates newGameStates)
    {
        Debug.Log($"Gamestate changed to {newGameStates}");
        if (newGameStates == GameStates.Gameplay)
        {
            canControl = true;
        }
        else if (newGameStates is GameStates.Complete or GameStates.Fail)
        {
            canControl = false;
        }
    }
    #endregion

    #region Spawn Methods
    private void SpawnFruit()
    {
        Vector2 spawnPosition = GetClickedWorldPosition();
        Fruit fruitToInstantiate = spawnableFruits[nextFruitIndex];

        _currentFruit = Instantiate(
            fruitToInstantiate,
            spawnPosition,
            Quaternion.identity,
            fruitParent);

        SetNextFruitIndex();
    }

    private void SetNextFruitIndex()
    {
        nextFruitIndex = Random.Range(0, spawnableFruits.Length);

        onNextFruitIndexSet?.Invoke();
    }
    public string GetNextFruitName()
    {
        return spawnableFruits[nextFruitIndex].name;
    }
    public Sprite GetNextFruitSprite()
    {
        return spawnableFruits[nextFruitIndex].GetSprite();
    }
    private void MergeProcessedCallback(FruitType fruitType, Vector2 spawnPosition)
    {
        for (int i = 0; i < fruitPrefabs.Length; i++)
        {
            if (fruitPrefabs[i].GetFruitType() == fruitType)
            {
                SpawnMergedFruit(fruitPrefabs[i], spawnPosition);
                break;
            }
        }
    }
    private void SpawnMergedFruit(Fruit fruit, Vector2 spawnPosition)
    {
        Fruit fruitInstance = Instantiate(fruit, spawnPosition, Quaternion.identity, fruitParent);
        fruitInstance.EnablePhysics();
    }
    #endregion

    #region Utility Methods
    private Vector2 GetClickedWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 worldClickedPosition = GetClickedWorldPosition();
        worldClickedPosition.y = fruitSpawnPositionY;
        return worldClickedPosition;
    }

    private void PlaceLineAtClickedPosition()
    {
        fruitSpawnLine.SetPosition(0, GetSpawnPosition());
        fruitSpawnLine.SetPosition(1, GetSpawnPosition() + Vector2.down * 5);
    }

    private void HideLine()
    {
        fruitSpawnLine.enabled = false;
    }

    private void DisplayLine()
    {
        fruitSpawnLine.enabled = true;
    }

    private void StartControlTimer()
    {
        Invoke("StopControlTimer", spawnDelay);
    }

    private void StopControlTimer()
    {
        canControl = true;
    }
    #endregion

    #region Gizmos
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (!enableGizmos)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(-50, fruitSpawnPositionY, 0), new Vector3(50, fruitSpawnPositionY, 0));
    }

#endif
    #endregion
}
