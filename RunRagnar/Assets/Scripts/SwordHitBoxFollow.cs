using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBoxFollow : MonoBehaviour
{

    public GameObject player;
    PlayerController controller;
    public Vector3 Spawnposition;
    private bool hasTurned = false;
    private float directionalOffset = 1.1f;


    private void Start()
    {
        controller = FindObjectOfType<PlayerController>();
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    private void Update()
    {
        Debug.Log(hasTurned);
        if (player != null && controller.GetHitStun() == false)
        {
           
            Spawnposition = player.transform.position;
            Spawnposition.x += directionalOffset;

            if (controller.GetDirection() == false && hasTurned == false)
            {
                directionalOffset *= -1;
                hasTurned = true;
            }
            gameObject.transform.position = Spawnposition;
        }
    }
  /*  public void Hit()
    {
        if (player != null && controller.GetHitStun() == false)
        {

            Spawnposition = player.transform.position;
            Spawnposition.x += directionalOffset;

            if (controller.GetDirection() == false && hasTurned == false)
            {
                directionalOffset *= -1;
            }
            gameObject.transform.position = Spawnposition;
        }
    }*/

    public void TurnBool()
    {
        hasTurned = false;
    }
}
       
