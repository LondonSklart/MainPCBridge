using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHitbox : MonoBehaviour {



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            FindObjectOfType<PlayerController>().TakeDamage(1000);
        }
    }
}
