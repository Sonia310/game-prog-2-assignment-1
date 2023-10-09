using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public CharacterMovement Player;
    public Transform spawnPoint;
    public GameObject DoubleJumpParticles;
    float rotationSpeed = 2.0f;
    float maxTime = 1.3f;
    float timer = 0.0f;
    float speed = 0.25f;
    Vector3 movement = new Vector3(0, -1, 0);

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

    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Instantiate(DoubleJumpParticles, spawnPoint.transform.position, spawnPoint.transform.rotation), 3);
            gameObject.SetActive(false);
            Player.setDoubleJump(true);

            Invoke("ReactivatePowerUp", 30);

        }
    }

    public void ReactivatePowerUp()
    {
        gameObject.SetActive(true);
    }
}
