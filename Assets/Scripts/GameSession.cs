using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // Config params
    [SerializeField] int maxLevel = 4;
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] Button resetButton;
    [SerializeField] bool isAutoPlayEnabled;

    // State variables
    [SerializeField] int totalScore = 0;
    [SerializeField] int currentScore = 0;

    // Must have only one game session
    private void Awake()
    {
        int countGameSessions = FindObjectsOfType<GameSession>().Length;
        if (countGameSessions > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject); // Don't destroy the original instance when going to the next scene
        }
    }

    private void Start()
    {
        currentScoreText.text = currentScore.ToString();
        totalScoreText.text = totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        currentScoreText.text = currentScore.ToString();
    }

    public void EndGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void LevelUp()
    {
        totalScore += currentScore;
        totalScoreText.text = totalScore.ToString();
        currentScore = 0;
        currentScoreText.text = currentScore.ToString();
    }

    public void ResetLevel()
    {
        currentScore = 0;
        currentScoreText.text = currentScore.ToString();
    }
}
