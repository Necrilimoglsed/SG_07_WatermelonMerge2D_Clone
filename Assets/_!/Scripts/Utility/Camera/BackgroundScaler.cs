using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScaler : MonoBehaviour
{
    [SerializeField] private bool isAspectRatio;

    private void Start()
    {
        var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        var worldSpaceWidth = topRightCorner.x * 2;
        var worldSpaceHeight = topRightCorner.y * 2;

        var spriteSize = GetComponent<SpriteRenderer>().bounds.size;

        var scaleFactorX = worldSpaceWidth / spriteSize.x;
        var scaleFactorY = worldSpaceHeight / spriteSize.y;

        if (isAspectRatio)
        {
            if (scaleFactorX > scaleFactorY)
            {
                scaleFactorY = scaleFactorX;
            }
            else
            {
                scaleFactorX = scaleFactorY;
            }
        }

        transform.localScale = new Vector2(scaleFactorX, scaleFactorY);
    }
}
