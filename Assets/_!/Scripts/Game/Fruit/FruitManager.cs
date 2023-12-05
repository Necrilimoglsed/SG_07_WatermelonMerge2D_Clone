using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private Transform itemSpawnParent;
    [SerializeField] private Transform gameOverLine;
    [SerializeField] private FruitVisual fruitVisualPrefab;
    [SerializeField] private FruitFactory _fruitFactory;
    //[SerializeField] private Fruit fruitPrefab;
    public FruitVisual FruitVisualPrefab => fruitVisualPrefab;
    private List<Fruit> _fruits = new List<Fruit>();

    // Placeholder //LevelData _currentLevelData;
    // Placeholder //LevelManager _levelManager;
    // Placeholder //private int _spawnAmount;

    private InputHandler _inputHandler;
    private List<int> _levelItemIndexes = new List<int>();

    private void Start()
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
    public int GetRandomID()
    {
        return _levelItemIndexes.RemoveRandom();
    }
    
    private void SpawnFruit()
    {
        var fruit = _fruitFactory.Create(itemSpawnParent, this);
        Vector2 spawnPosition = MousePosition();
        spawnPosition.y = gameOverLine.position.y -0.2f;
        fruit.transform.position = spawnPosition;
        //Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
        _fruits.Add(fruit);
    }
    private Vector2 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
