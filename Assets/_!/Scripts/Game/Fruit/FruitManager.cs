using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [SerializeField] private GameObject fruitPrefab;

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
        Instantiate(fruitPrefab, MousePosition(), Quaternion.identity);
    }
    private Vector2 MousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
