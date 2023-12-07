using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI gameScoreText;
    [SerializeField] private TextMeshProUGUI watermelonScoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header("Settings")]
    private int _score;
    private int _watermelonScore;
    private int _highScore;

    private void Awake()
    {
        LoadHighScore();
        MergeManager.onMergeProcessed += MergeProcessedCallback;
        ActionHandler<GameStates>.Register(ActionKey.GameStateChangeKey, GameStateChangedCallback);
    }
    private void Start()
    {
        UpdateScoreText();
    }

    private void OnDestroy()
    {
        MergeManager.onMergeProcessed -= MergeProcessedCallback;
        ActionHandler<GameStates>.Unregister(ActionKey.GameStateChangeKey, GameStateChangedCallback);
    }

    #region Callback Methods

    private void MergeProcessedCallback(FruitType fruitType, Vector2 ignoreThis)
    {
        _score += (int)Mathf.Pow(2,(int)fruitType);

        if ((int)fruitType == 11)
        {
            Debug.LogWarning("Melon merge");
            _watermelonScore++;
            UpdateWatermelonScoreText();
        }
        UpdateScoreText();
    }
    private void GameStateChangedCallback(GameStates newGameState)
    {
        if (newGameState == GameStates.Fail)
        {
            UpdateGameOverScore();
            UpdateGameOverScoreText();
        }
    }

    #endregion

    #region Update UI Text Methods
    private void UpdateScoreText()
    {
        gameScoreText.text = _score.ToString();
    }
    private void UpdateWatermelonScoreText()
    {
        watermelonScoreText.text = _watermelonScore.ToString();
    }

    private void UpdateGameOverScoreText()
    {
        highScoreText.text = _highScore.ToString();
        gameOverScoreText.text = _score.ToString();
    }
    #endregion

    #region Data Methods
    private void UpdateGameOverScore()
    {
        if (_score > _highScore)
        {
            _highScore = _score;
            SaveHighScore();
        }
    }
    private void LoadHighScore()
    {
        _highScore = DataHandler.Score;
    }
    private void SaveHighScore()
    {
        DataHandler.Score = _highScore;
    }
    #endregion
}
