using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float yOffset = 100f;
    public float scrollSpeed = 10;
    private bool gameIsOn = false;
    Vector3 playerPosition;
    Manager manager;
    AudioManager audio;

    // Use this for initialization
    void Start ()
    {
        manager = Manager.Instance;
        audio = FindObjectOfType<AudioManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null && gameIsOn == true)
        {
            gameObject.transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);
            manager.IncreaseScore(1);





        }
	}
    public void StartGame()
    {
        audio.StartTheme();
        gameIsOn = true;
    }
    public void EndGame()
    {
        gameIsOn = false;
    }
}
