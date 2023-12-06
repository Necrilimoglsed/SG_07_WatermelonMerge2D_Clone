using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Data")]
    [SerializeField] private FruitType fruitType;
    private bool hasCollided;
    //private bool canBeMerged;

    [Header("Actions")]
    public static Action<Fruit, Fruit> onCollisionWithFruit;

    private FruitManager _fruitManager;

    private const float TweenMoveTime = .2f;
    private const float TweenMoveSpeed = 5f;
    private const float TweenDisappearTime = .28f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;

        if (collision.collider.TryGetComponent(out Fruit otherFruit))
        {
            if (otherFruit.GetFruitType() != fruitType)
            {
                return;
            }

            onCollisionWithFruit?.Invoke(this, otherFruit);
        }
    }
    public void MoveTo(Vector2 targetPosition)
    {
        transform.position = targetPosition;
    }
    public void EnablePhysics()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled = true;
    }
    public FruitType GetFruitType()
    {
        return fruitType;
    }

    public Sprite GetSprite()
    {
        return spriteRenderer.sprite;
    }
    public bool HasCollided()
    {
        return hasCollided;
    }
}
