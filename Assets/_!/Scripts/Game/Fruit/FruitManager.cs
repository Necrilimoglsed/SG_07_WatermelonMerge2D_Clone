using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private Transform itemSpawnParent;
    [SerializeField] private Transform gameOverLine;
    [SerializeField] private FruitVisual fruitVisualPrefab;
    [SerializeField] private GameObject fruitPrefab;
    [SerializeField] private FruitFactory _fruitFactory;
    public FruitVisual FruitVisualPrefab => fruitVisualPrefab;

    // Placeholder //private List<Fruit> _fruits = new List<Fruit>();
    // Placeholder //LevelData _currentLevelData;
    // Placeholder //LevelManager _levelManager;
    // Placeholder //private int _spawnAmount;
    private List<int> _levelItemIndexes = new List<int>();

    private InputHandler _inputHandler;
    

    private void Awake()
    {
        _inputHandler = new InputHandler();
        _inputHandler.OnPointerDownAction += SpawnFruit;
    }

    private void OnDestroy()
    {
        _inputHandler.OnPointerDownAction -= SpawnFruit;

    }

    private void Update()
    {
        _inputHandler.PointerUpdate();
    }

    private void SpawnFruit()
    {
        var fruit = _fruitFactory.Crate(itemSpawnParent);
        Vector2 spawnPosition = MousePosition();
        spawnPosition.y = gameOverLine.position.y -0.2f;
        fruit.transform.position = spawnPosition;
        //Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
    }
    private Vector2 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    public int GetRandomId()
    {
        return 0;
    }
}
