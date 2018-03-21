using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAuthorities : MonoBehaviour
{
    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(5);
            player.GetComponent<Rigidbody>().AddForce(10, 0, 0, ForceMode.Impulse);
            //player.GetComponent<Rigidbody>().AddExplosionForce(10, gameObject.transform.position, 100, 1f, ForceMode.Impulse);
        }
    }

}
