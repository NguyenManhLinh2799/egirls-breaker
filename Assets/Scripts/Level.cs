using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    // Config Params
    [SerializeField] int countBlocks; // Serialized for debugging purposes
    [SerializeField] TextMeshProUGUI levelText;

    // Cached references
    SceneLoader sceneLoader;

    // State variables
    [SerializeField] int currentLevel;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        levelText.text = currentLevel.ToString();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void IncreaseBlocks()
    {
        countBlocks++;
    }

    public void BlockDestroyed()
    {
        countBlocks--;
        if (countBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
