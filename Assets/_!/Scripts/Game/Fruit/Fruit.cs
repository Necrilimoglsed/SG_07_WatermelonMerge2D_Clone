using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //[SerializeField] private Rigidbody2D rigidbody;

    private FruitManager _fruitManager;
    private FruitVisual _fruitVisual;

    //private int _id;
    //private MeshCollider _meshCollider;
    private const float TweenMoveTime = .2f;
    private const float TweenMoveSpeed = 5f;
    private const float TweenDisappearTime = .28f;

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

    



}
