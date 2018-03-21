using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyLever : MonoBehaviour
{
    public Wall Wall;
    public Animator animator;
    private bool leverOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Boom");
        if (other.transform.tag == "Sword" && leverOpen == false)
        {
            leverOpen = true;
            Wall.OpenWall("Fast");
            animator.Play("LeverPull");
        }
    }

}
