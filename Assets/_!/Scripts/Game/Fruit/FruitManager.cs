using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class FruitManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Fruit[] fruitPrefabs;
    [SerializeField] private LineRenderer fruitSpawnLine;
    [SerializeField] private Fruit[] spawnableFruits;
    private Fruit _currentFruit;

    [Header("Settings")]
    [SerializeField] private float fruitSpawnPositionY;

    [Header("Debug")]
    [SerializeField] private bool enableGizmos;

    //[SerializeField] private Transform fruitsParent;

    private void Awake()
    {
        MergeManager.onMergeProcessed += MergeProcessedCallback;
    }
    private void Start()
    {
        HideLine();
    }

    private void Update()
    {
        ManagePlayerInput();
    }

    private void ManagePlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseDownCallback();
        }
        else if (Input.GetMouseButton(0))
        {
            MouseDragCallback();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MouseUpCallback();
        }
    }

    private void MouseDownCallback()
    {
        DisplayLine();
        PlaceLineAtClickedPosition();

        SpawnFruit();
    }

    private void MouseDragCallback()
    {
        PlaceLineAtClickedPosition();
        //_currentFruit.transform.position = new Vector2(GetSpawnPosition().x, fruitSpawnPositionY);
        _currentFruit.transform.position = new Vector2(GetSpawnPosition().x, fruitSpawnPositionY);
    }

    private void MouseUpCallback()
    {
        HideLine();
        _currentFruit.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void SpawnFruit()
    {
        Vector2 spawnPosition = GetClickedWorldPosition();
        _currentFruit = Instantiate(fruitPrefabs[Random.Range(0, fruitPrefabs.Length)], spawnPosition, Quaternion.identity);
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
        Fruit fruitInstance = Instantiate(fruit, spawnPosition, Quaternion.identity);
    }

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
}
