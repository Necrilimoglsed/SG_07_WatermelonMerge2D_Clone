using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeManager : MonoBehaviour
{
    private Fruit lastSender;

    public static Action<FruitType, Vector2> onMergeProcessed;

    private void Start()
    {
        Fruit.onCollisionWithFruit += CollisionBetweenFruitsCallback;
    }
    private void OnDestroy()
    {
        
    }

    private void CollisionBetweenFruitsCallback(Fruit sender, Fruit otherFruit)
    {
        if (lastSender != null)
        {
            return;
        }

        lastSender = sender;

        MergeFruits(sender, otherFruit);

        Debug.Log("Collision detected by" + sender.name);
    }
    private void MergeFruits(Fruit sender, Fruit otherFruit)
    {
        FruitType mergeFruitState = sender.GetFruitType();
        mergeFruitState += 1;

        Vector2 fruitSpawnPos = sender.transform.position + otherFruit.transform.position / 2;

        Destroy(sender.gameObject);
        Destroy(otherFruit.gameObject);

        StartCoroutine(ResetLastSenderCoroutine());

        onMergeProcessed?.Invoke(mergeFruitState, fruitSpawnPos);
    }

    IEnumerator ResetLastSenderCoroutine()
    {
        yield return new WaitForEndOfFrame();
        lastSender = null;
    }
}
