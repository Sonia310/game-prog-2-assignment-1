using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public Text EndText;

    void Update() {
        UpdateEndText();
    }

    public void OnGameRestart() {
        GameManager.Instance.LoadGameLevelOne();
    }

    public void OnGameStop() {
        Application.Quit();
    }

    public void UpdateEndText() {
        EndText.text = "Congratulations! You had a score of " + GameManager.Instance.GetScore() + "!";
    }
}