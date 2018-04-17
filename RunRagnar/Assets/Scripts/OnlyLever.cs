using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyLever : MonoBehaviour
{
    public Wall Wall;
    public Animator animator;
    public AudioSource audio;
    private bool leverOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Sword" && leverOpen == false)
        {
            leverOpen = true;
            audio.Play();
            Wall.OpenWall("Fast");
            animator.Play("LeverPull");
        }
    }

}
