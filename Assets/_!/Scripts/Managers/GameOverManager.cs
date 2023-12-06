using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject deadline;
    [SerializeField] private Transform fruitParent;

    [Header("Timer")]
    [SerializeField] private float gameoverThreshold = 3f;
    private float timer;
    private bool timerOn;

    private void Start()
    {

    }

    private void Update()
    {
        ManageGameOver();
    }

    private void ManageGameOver()
    {
        if (timerOn)
        {
            ManageTimerOn();
        }
        else if (IsFruitAboveLine())
        {
            StartTimer();
        }
    }

    private void ManageTimerOn()
    {
        timer += Time.deltaTime;

        if (!IsFruitAboveLine())
        {
            StopTimer();
        }
        if (timer >= gameoverThreshold)
        {
            Gameover();
        }
    }

    private bool IsFruitAboveLine()
    {
        for (int i = 0; i < fruitParent.childCount; i++)
        {
            Fruit fruit = fruitParent.GetChild(i).GetComponent<Fruit>();

            if (!fruit.HasCollided())
            {
                continue;
            }

            if (IsFruitAboveLine(fruitParent.GetChild(i)))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsFruitAboveLine(Transform fruit)
    {
        if (fruit.position.y > deadline.transform.position.y)
        {
            return true;
        }
        return false;
    }
    private void StartTimer()
    {
        timer = 0;
        timerOn = true;
    }
    private void StopTimer()
    {
        timerOn = false;
    }
    private void Gameover()
    {
        Debug.LogError("Gameover");
    }
}
