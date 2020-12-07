using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Config params
    [SerializeField] uint secondsBeforeNextLevel = 1;

    // Cached references
    GameSession gameSession;

    // State variables
    private static int previousSceneIndex = 0;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    public void LoadGameOverScene()
    {
        UpdatePreviousScene();
        SceneManager.LoadScene("Game Over");
    }

    public void ReloadScene()
    {
        if (gameSession != null)
        {
            gameSession.ResetLevel();
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadPreviousScene()
    {
        if (gameSession != null)
        {
            gameSession.ResetLevel();
        }
        SceneManager.LoadScene(previousSceneIndex);
    }
    

    public void LoadNextScene()
    {
        StartCoroutine(WaitAndLoadNextScene());
    }

    public void LoadStartScene()
    {
        if (gameSession != null)
        {
            gameSession.EndGame();
        }
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void UpdatePreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        previousSceneIndex = currentSceneIndex;
    }

    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(secondsBeforeNextLevel);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        if (gameSession != null)
        {
            gameSession.LevelUp();
        }
    }
}
