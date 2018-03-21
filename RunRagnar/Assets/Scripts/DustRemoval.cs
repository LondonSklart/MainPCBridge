using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustRemoval : MonoBehaviour
{
    private bool timeractive = false;
    private float lifetime;

    private void Awake()
    {
        lifetime = Random.Range(1, 9);
    }

    private void Update()
    {
        if (timeractive == true)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        timeractive = true;
    }

}
