using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLine : MonoBehaviour
{
    private void Start()
    {
        var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}
