using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public float yOffset = 100f;
    public float scrollSpeed = 10;
    private bool gameIsOn = false;
    Vector3 playerPosition;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player != null && gameIsOn == true)
        {
            gameObject.transform.Translate(scrollSpeed * Time.deltaTime, 0, 0);






            /*
            playerPosition = player.transform.position;
            playerPosition.z += -10f;
            gameObject.transform.position = playerPosition;*/
        }
	}
    public void StartGame()
    {
        gameIsOn = true;
    }
}
