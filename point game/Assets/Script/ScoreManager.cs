using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int currentScore;
    public int savedScore = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }

        if (scoreText != null && scoreText.transform.parent != null)
        {
            DontDestroyOnLoad(scoreText.transform.parent.gameObject);
        }
    }

    public void AddScore(int points)
    {
        currentScore += points;
        Debug.Log("Current Score: " + currentScore);
        UpdatePointText();
    }

    public void ResetScore()
    {
        currentScore = 0;
        Debug.Log("Score Reset. Current Score: " + currentScore);
        UpdatePointText();
    }

    public void SaveScore()
    {
        savedScore = currentScore;
    }
    
    public void UpdatePointText()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName != "GameClear" && sceneName != "GameOver")
        {
            scoreText.text = "" + currentScore.ToString();
        }
        else
        {
            scoreText.text = "";
        }
    }
       private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdatePointText();
    }
}
