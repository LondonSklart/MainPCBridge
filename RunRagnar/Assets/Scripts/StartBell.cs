using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBell : MonoBehaviour
{
    CameraController cameraController;
    Animator animator;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
        animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {

      
            Debug.Log("ass");
        animator.SetTrigger("Game");
            cameraController.StartGame();
        
    }
}
