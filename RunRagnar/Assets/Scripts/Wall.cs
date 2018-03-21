using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    PlayerController player;
    Quaternion rotation;
    public GameObject dustcloud;
    [SerializeField]
    float health = 100;
    float maxOpenHeight;
    bool goingDown = true;
    Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        targetPosition = gameObject.transform.position;
        maxOpenHeight = gameObject.transform.position.y + 5;
    }
    private void Update()
    {
        if (goingDown)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPosition, 1 * Time.deltaTime);
        }
   

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.GetStomp())
        {
            TakeDamage(player.GetDamage());
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        else if (collision.gameObject.tag == "Sword")
        {
            TakeDamage(player.GetDamage());
            if (health <= 0)
            {
                Instantiate(dustcloud,gameObject.transform.position,rotation);

                Destroy(gameObject);
            }
        }
    }

    public void OpenWall(string how)
    {
        if (how == "Slow")
        {
       if (gameObject.transform.position.y < maxOpenHeight)
        {
            transform.Translate(0, 0.5f, 0);
                Debug.Log("dab");

        }
        }
        else
        {
            gameObject.transform.Translate(0, 5, 0);
            goingDown = false;

        }


    }

    private void TakeDamage(float damage)
    {
        health = health -damage;
    }
}
