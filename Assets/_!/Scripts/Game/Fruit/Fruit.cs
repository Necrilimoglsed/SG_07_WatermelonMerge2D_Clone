using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private FruitManager _fruitManager;
    public FruitType fruitType;

    private const float TweenMoveTime = .2f;
    private const float TweenMoveSpeed = 5f;
    private const float TweenDisappearTime = .28f;

    public static Action<Fruit, Fruit> onCollisionWithFruit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Fruit otherFruit))
        {
            if (otherFruit.GetFruitType() != fruitType)
            {
                return;
            }

            onCollisionWithFruit?.Invoke(this, otherFruit);
        }
    }

    public FruitType GetFruitType()
    {
        return fruitType;
    }

    

  



}
