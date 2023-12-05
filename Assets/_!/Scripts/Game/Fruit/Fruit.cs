using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fruit : MonoBehaviour, IFactoryElement
{
    //[SerializeField] private Rigidbody2D rigidbody;

    private FruitManager _fruitManager;
    private FruitVisual _fruitVisual;

    //private MeshCollider _meshCollider;
    private int _id;
    public int ID => _id;

    private const float TweenMoveTime = .2f;
    private const float TweenMoveSpeed = 5f;
    private const float TweenDisappearTime = .28f;

    public void Prepare(object customParameter = null)
    {
        _fruitManager = (FruitManager)customParameter;
        GenerateVisual();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Fruit fruit))
        {
            Destroy(fruit.gameObject);
        }
    }
    

    private void Start()
    {
        ActionHandler.Raise(ActionKey.OnFruitCollisionKey);
    }
    private void GetID()
    {
        _id = _fruitManager.GetRandomID();
    }
    private void GenerateVisual()
    {
        _fruitVisual = Instantiate(_fruitManager.FruitVisualPrefab, transform);
        _fruitVisual.Prepare(_id);
    }



}
