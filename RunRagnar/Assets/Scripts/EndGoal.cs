using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public GameObject victoryScreen;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Time.timeScale = 0;
            FindObjectOfType<CameraController>().EndGame();
            victoryScreen.SetActive(true);
        }
    }

}
