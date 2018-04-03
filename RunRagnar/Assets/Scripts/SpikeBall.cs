using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour {

    public float shotSpeed = 10;
    private float shotDuration = 2;
    PlayerController player;
    Vector3 knockBackPosition;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        if (GetComponentInParent<EnemyDropper>() != null)
        {
            shotDuration = GetComponentInParent<EnemyDropper>().GetShotDuration();
        }
        else
        {
            shotDuration = GetComponentInParent<GreaterDropper>().GetShotDuration();
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(0, -1 * shotSpeed * Time.deltaTime, 0);
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
