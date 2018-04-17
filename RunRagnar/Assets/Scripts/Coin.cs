using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Coin : MonoBehaviour
{
    Animation animation;
    public AudioSource sound;

    private void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            animation.Play();
            sound.Play();
            Manager.Instance.IncreaseScore(100);
            Destroy(gameObject,animation.clip.length);
        }
    }



}
