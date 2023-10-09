using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneBehaviour : MonoBehaviour
{
    public GameObject Player;
    Vector3 originalPlayerPosition;

    void Start()
    {
        originalPlayerPosition = Player.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        GameManager.Instance.RestartLevel();
    }

}
