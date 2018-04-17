using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBell : MonoBehaviour
{
    CameraController cameraController;
    Animator animator;
    public AudioSource audio;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

      
        animator.SetTrigger("Game");
        audio.Play();
        cameraController.StartGame();
        
    }
}
