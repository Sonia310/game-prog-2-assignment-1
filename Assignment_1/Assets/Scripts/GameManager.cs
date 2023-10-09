using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static float Score = 0;
    public float LevelScore = 0;

    private void Awake() {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetScore(float sum) {
        Score += sum;
    }

    public float GetScore() {
        return Score;
    }

    public void LoadNextLevel() {
        LevelScore = Score;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartLevel() {
        Score = LevelScore;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadGameLevelOne() {
        Score = 0;
        LevelScore = 0;
        SceneManager.LoadScene(1);
    }
}