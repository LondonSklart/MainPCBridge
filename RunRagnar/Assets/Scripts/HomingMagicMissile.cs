using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMagicMissile : MonoBehaviour {

    public float shotSpeed = 10;
    private float shotDuration;
    PlayerController player;
    Vector3 knockBackPosition;
     RaycastHit hit;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        shotDuration = GetComponentInParent<EnemyMage>().GetShotDuration();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(-1 * shotSpeed * Time.deltaTime, 0, 0);
        Debug.DrawRay(gameObject.transform.position,gameObject.transform.right*-1);
        Physics.Raycast(gameObject.transform.position, gameObject.transform.right * -1,out  hit, 1 << 9);


        if (player != null)
        {



            if (gameObject.transform.position.y < player.transform.position.y && gameObject.transform.position.x > player.transform.position.x && hit.transform.tag != "Player")
            {
                gameObject.transform.Rotate(0, 0, -1);
            }
            if (gameObject.transform.position.y > player.transform.position.y && gameObject.transform.position.x > player.transform.position.x && hit.transform.tag != "Player")
            {
                gameObject.transform.Rotate(0, 0, 1);
            }
        }
        
        Destroy(gameObject, shotDuration);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            knockBackPosition = gameObject.transform.position;
            knockBackPosition.x += 5;
            player.TakeDamage(3f);
            player.GetComponent<Rigidbody>().AddExplosionForce(5, knockBackPosition, 100, 50, ForceMode.Impulse);
            Destroy(gameObject);
        }

    }

}
