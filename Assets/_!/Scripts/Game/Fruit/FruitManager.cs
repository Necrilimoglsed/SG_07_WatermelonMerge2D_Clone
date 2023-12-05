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
    //[SerializeField] private GameObject fruitPrefab;
    public FruitVisual FruitVisualPrefab => fruitVisualPrefab;

    // Placeholder //private List<Fruit> _fruits = new List<Fruit>();
    // Placeholder //LevelData _currentLevelData;
    // Placeholder //LevelManager _levelManager;
    // Placeholder //private int _spawnAmount;
    private List<int> _levelItemIndexes = new List<int>();

    [SerializeField] private FruitFactory _fruitFactory;
    private InputHandler _inputHandler;

    [Inject]
    public void Init(FruitFactory fruitFactory)
    {
        _fruitFactory = fruitFactory;
    }
    private void Awake()
    {
        _inputHandler = new InputHandler();
        _fruitFactory = new FruitFactory();
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
        //Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
        //fruit.transform.position = spawnPosition;
        var fruit = _fruitFactory.Create(itemSpawnParent, this);
        Vector2 spawnPosition = MousePosition();
        spawnPosition.y = gameOverLine.position.y -0.2f;
        fruit.transform.position = spawnPosition;
    }
    private Vector2 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
