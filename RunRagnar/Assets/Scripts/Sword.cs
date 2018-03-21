using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public GameObject Edgehitbox;
    public GameObject player;
    GameObject hitbox;
    Vector3 playerPosition;
    public Animator myAnimator;
    private bool canSwing = true;
    private float startingSwingDuration = 0.2f;
    private float swingDuration;

    private void Start()
    {
        swingDuration = startingSwingDuration;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.K) && canSwing == true)
        {
            //playerPosition = player.transform.position;
            //playerPosition.x += 1f;
            //Instantiate(Edgehitbox,playerPosition,transform.rotation);
            Hit();
            myAnimator.SetBool("Attacking",true);
  
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



