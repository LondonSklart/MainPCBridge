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
    public int jumpHeight = 10;
    private bool lookingRight = true;
    private int direction = 1;
    private float hitStunTimer = 0f;
    private bool grounded = false;
    Vector3 playerSize = new Vector3(0.8f, 0.0001f, 0.8f);
    Vector3 stompvector = new Vector3(0, -1200, 0);
    Rigidbody playerbody;
    Animator myAnimator;
    AudioManager audioManager;
    Vector3 movement;
    Vector3 myNegativeVector;
    Vector3 lineVector;
    Vector3 lineVector2;
    Collider playerCollider;
    RaycastHit hit;
    RaycastHit middleHit;
    RaycastHit lowerHit;
    public AudioSource jumpingSound;
    public AudioSource getHitSound;
    public SwordHitBoxFollow sword;
    public Image healthbar;

    private void Start()
    {
        playerCollider = gameObject.GetComponent<Collider>();
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
        lineVector = gameObject.transform.position;
        lineVector.y -= 0.49f;
        lineVector.x -= 0.49f;
        lineVector2 = lineVector;
        lineVector2.x += 1f;


        Debug.DrawRay(lineVector, gameObject.transform.up * -1);
        Debug.DrawRay(lineVector2, gameObject.transform.up * -1);

        if (Physics.Raycast(lineVector, gameObject.transform.up * -1, 0.2f)||Physics.Raycast(lineVector2,gameObject.transform.up*-1,0.2f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }


        if (hitStun == false)
        {
            movement = new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime, playerbody.velocity.y, 0);
            playerbody.velocity = movement;

            Vector3 myVector = new Vector3(gameObject.transform.right.x, gameObject.transform.up.y, 0);
            myNegativeVector = gameObject.transform.position;
            myNegativeVector.y -=0.49f;
            Ray ray = new Ray(gameObject.transform.position,myVector);
            Ray lowerRay = new Ray(myNegativeVector, gameObject.transform.right);
            Ray middleRay = new Ray(gameObject.transform.position, gameObject.transform.right);

            Physics.Raycast(ray, out hit, 0.8f);
            Physics.Raycast(middleRay,out middleHit ,0.6f);
            Physics.Raycast(lowerRay, out lowerHit, 0.6f);



            if (hit.transform != null)
            {
                if (hit.transform.tag == "Ground")
                {
                    playerbody.velocity = new Vector2(0, playerbody.velocity.y);

                }
            }
            if (middleHit.transform != null)
            {
                if (middleHit.transform.tag == "Ground")
                {
                    playerbody.velocity = new Vector2(0, playerbody.velocity.y);

                }
            }
            if (lowerHit.transform != null)
            {
                if (lowerHit.transform.tag == "Ground")
                {
                    playerbody.velocity = new Vector2(0, playerbody.velocity.y);
                }
            }


        }
        Debug.DrawRay(myNegativeVector, gameObject.transform.right);

        if (hitStun == false)
        {



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

            }
            if (Input.GetKeyUp(KeyCode.D))
            {

                audioManager.running = false;
                myAnimator.SetBool("Running", false);
            }
            if (Input.GetKey(KeyCode.A))
            {

                audioManager.running = true;



                if (lookingRight == true)
                {
                    gameObject.transform.Rotate(0, 180, 0);
                    direction = 1;
                    lookingRight = false;
                }
                myAnimator.SetBool("Running", true);
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
        if (hitStun == false)
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

}
