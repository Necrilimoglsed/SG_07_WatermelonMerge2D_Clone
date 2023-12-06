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
    private bool isGameplay;

    private void Start()
    {
        ActionHandler<GameStates>.Register(ActionKey.GameStateChangeKey, EnableGameOverLine);
    }

    private void Update()
    {
        ManageGameOver();
    }

    private void EnableGameOverLine(GameStates newGameState)
    {
        if (newGameState == GameStates.Gameplay)
        {
            isGameplay = true;
        }
        else
        {
            isGameplay = false;
        }
    }
    private void ManageGameOver()
    {
        if (!isGameplay)
        {
            return;
        }
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
        isGameplay = false;
        ServiceProvider.GetService<GameService>().SetNewGameState(GameStates.Fail);
    }
}
