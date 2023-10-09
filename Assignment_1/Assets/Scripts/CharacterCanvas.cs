using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterCanvas : MonoBehaviour
{
    public Text ScoreText;

    void Update() {
        UpdateScore();
    }

    public void UpdateScore() {
        ScoreText.text = "Score: " + GameManager.Instance.GetScore();
    }

    public Text GetScore() {
        return ScoreText;
    }
}
