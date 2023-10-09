using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelThreeBottomTrapRight : MonoBehaviour
{
    public float maxTime = 1.0f;
    float timer = 0.0f;
    float speed = 2f;
    Vector3 movement = new Vector3(1f, 0, 0);
    public GameObject Player;
    Vector3 originalPlayerPosition;

    void Start()
    {
        originalPlayerPosition = Player.transform.position;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            movement = -1.0f * movement;
            timer = 0.0f;
        }

        transform.position = transform.position - movement * speed * Time.deltaTime;
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