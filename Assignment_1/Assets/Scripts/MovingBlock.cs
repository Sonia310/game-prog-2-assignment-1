using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingBlock : MonoBehaviour
{
    public float maxTime = 1f;
    float timer = 0.0f;
    float speed = 2f;
    Vector3 movement = new Vector3(0, 0, 1);
    
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
}