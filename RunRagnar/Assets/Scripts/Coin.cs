using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Animation animation;

    private void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            animation.Play();
            Manager.Instance.IncreaseScore(5000);
            Destroy(gameObject,animation.clip.length);
        }
    }



}
