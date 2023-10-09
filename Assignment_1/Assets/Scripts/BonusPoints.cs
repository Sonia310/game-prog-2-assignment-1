using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BonusPoints : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject PointParticles;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(Instantiate(PointParticles, spawnPoint.transform.position, spawnPoint.transform.rotation), 3);
            GameManager.Instance.SetScore(50.0f);
            gameObject.SetActive(false);
        }
    }
}
