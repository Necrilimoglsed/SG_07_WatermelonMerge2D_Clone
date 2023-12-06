using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FruitManager))]
public class FruitManagerUI : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Image nextFruitImage;
    [SerializeField] private TextMeshProUGUI nextFruitText;
    private FruitManager fruitManager;

    private void Start()
    {
        fruitManager = GetComponent<FruitManager>();
    }

    private void Update()
    {
        nextFruitText.text = fruitManager.GetNextFruitName();
        nextFruitImage.sprite = fruitManager.GetNextFruitSprite();
    }
}
