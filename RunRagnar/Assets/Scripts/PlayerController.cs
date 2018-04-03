using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {


    public float speed = 10;
    public float startinghealth = 10;
    public float health;
    private float damage = 5;
    private bool hasJumped = false;
    private bool hasStomped = false;
    private bool hitStun = false;
    private int jumpHeight = 10;
    private bool lookingRight = true;
    private int direction = 1;
    private float hitStunTimer = 0f;
    private bool grounded = false;
    Vector3 playerSize = new Vector3(0.8f, 0.0001f, 0.8f);
    Vector3 stompvector = new Vector3(0, -1200, 0);
    Rigidbody playerbody;
    Animator myAnimator;
    AudioManager audioManager;
    public AudioSource jumpingSound;
    public AudioSource getHitSound;
    public SwordHitBoxFollow sword;
    public Image healthbar;

    private void Start()
    {
        health = startinghealth;
        audioManager = AudioManager.instance;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        playerbody = gameObject.GetComponent<Rigidbody>();
        myAnimator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update ()
    {
        if (hitStunTimer >= 0f)
        {
            hitStunTimer -= Time.deltaTime;
            if (hitStunTimer < 0)
            {
                hitStun = false;
            }
        }
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.up * -1, 1f))
        {
            grounded = true;
        }
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.up * -1, 1f) == false)
        {
            grounded = false;
        }



        if (hitStun == false)
        {

            if (Input.GetKeyDown(KeyCode.D))
            {
               // runningSound.Play();
               // audioManager.Play("RunSound");
            }


            if (Input.GetKey(KeyCode.D))
            {
                audioManager.running = true;

                if (lookingRight != true)
                {
                    gameObject.transform.Rotate(0, 180, 0);
                    direction = 1;
                    lookingRight = true;
                }
                myAnimator.SetBool("Running", true);

                gameObject.transform.Translate(direction * speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                audioManager.running = false;
                myAnimator.SetBool("Running", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                audioManager.running = true;

                if (Input.GetKeyDown(KeyCode.A))
                {


                }

                if (lookingRight == true)
                {
                    gameObject.transform.Rotate(0, 180, 0);
                    direction = 1;
                    lookingRight = false;
                }
                myAnimator.SetBool("Running", true);
                gameObject.transform.Translate(direction * speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                audioManager.running = false;
                myAnimator.SetBool("Running", false);
            }
            if (Input.GetKeyDown(KeyCode.W) && grounded == true)
            {

                jumpingSound.Play();
                    playerbody.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
                    hasJumped = true;

            }
            if (Input.GetKeyDown(KeyCode.J) && grounded == false && hasStomped == false)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(stompvector * Time.deltaTime, ForceMode.Impulse);
                hasStomped = true;
            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
        hasJumped = false;
        }

        if (collision.gameObject.tag != "Enemy")
        {
            hasStomped = false;
        }

    }
    public bool GetStomp()
    {
        return hasStomped;
    }
    public void SetStomp(bool stomp)
    {
        if (stomp)
        {
            hasStomped = true;
        }
        else
        {
            hasStomped = false;
        }
    }
    public float GetDamage()
    {
        return damage;
    }
    public bool GetDirection()
    {
        return lookingRight;
    }
    public bool GetHitStun()
    {
        return hitStun;
    }
    public void HitStun()
    {
        hitStun = true;
        hitStunTimer = 0.5f;
    }
    public bool GetGrounded()
    {
        return grounded;
    }
    public void TakeDamage (float damage)
    {
        HitStun();
        audioManager.GetHitSound();
        health -= damage;
        healthbar.fillAmount = health / startinghealth;

        if (health <= 0)
        {
            audioManager.PlayDeathSound();
            Destroy(gameObject);
        }
    }
}
