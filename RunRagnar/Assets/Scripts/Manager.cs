using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    private float score;
    public Text scoreText;

    public static Manager Instance { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start()
    {
        scoreText.text = "Score: 0";
    }


    public void IncreaseScore(float increase)
    {
        score += increase;
        scoreText.text = "Score: " + score;
    }
}
