using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header("Data")]
    public FruitType FruitType;
    private bool hasCollided;

    [Header("Actions")]
    public static Action<Fruit, Fruit> onCollisionWithFruit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasCollided = true;

        if (collision.collider.TryGetComponent(out Fruit otherFruit))
        {
            if (otherFruit.GetFruitType() != FruitType)
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
        return FruitType;
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
