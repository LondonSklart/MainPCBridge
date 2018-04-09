using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sword : MonoBehaviour {

    public GameObject Edgehitbox;
    public GameObject player;
    PlayerController playerController;
    GameObject hitbox;
    Vector3 playerPosition;
    public Animator myAnimator;
    public AudioSource swingSound;
    private bool canSwing = true;
    private float startingSwingDuration = 0.2f;
    private float swingDuration;
    public float swingTimer;
    private float swingCache;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        swingDuration = startingSwingDuration;
    }

    // Update is called once per frame
    void Update ()
    {
        if (swingCache > 0)
        {
            swingCache -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.K) && swingCache <= 0)
        {
            swingSound.Play();
            Hit();
            myAnimator.SetBool("Attacking",true);
            swingCache = swingTimer;
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (Edgehitbox.activeSelf == true)
            {

           
                swingDuration -= Time.deltaTime;
                if (swingDuration < 0)
                {
                    myAnimator.SetBool("Attacking", false);
                    swingDuration = startingSwingDuration;
                gameObject.transform.Rotate(0, 0, 100);
                Edgehitbox.SetActive(false);
                }
            } 
        }
          
        if (Input.GetKeyUp(KeyCode.K) && Edgehitbox.activeSelf == true)
        {
            myAnimator.SetBool("Attacking",false);
            gameObject.transform.Rotate(0, 0, 100);
            Edgehitbox.SetActive(false);
        }

    }


 


    private void Hit()
    {

        Edgehitbox.SetActive(true);
        gameObject.transform.Rotate(0, 0, -100);

    }
    private void Swing()
    {
        StartCoroutine(SwingTimer());

    }
    IEnumerator SwingTimer()
    {
        yield return new WaitForSeconds(1);
    }

}



