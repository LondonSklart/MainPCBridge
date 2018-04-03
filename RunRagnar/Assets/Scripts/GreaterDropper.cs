using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreaterDropper : MonoBehaviour
{

    PlayerController player;
    public GameObject spikeBall;
    public GameObject bloodSpray;
    public float damage = 2;
    public float startingHealth = 10;
    private float shotTimer = 2;
    private float health;
    [SerializeField]
    private float shotDuration = 2;
    Vector3 knockBackPosition;
    Quaternion rotation;
    Quaternion shotRotation;
    public Image healthbar;
    public ParticleSystem bloodSplash;
    public GameObject leftBallSpawn;
    public GameObject middleBallSpawn;
    public GameObject rightBallSpawn;

    // Use this for initialization
    void Start()
    {
        health = startingHealth;
        player = FindObjectOfType<PlayerController>();
        rotation.x = Random.Range(1, 10);
        rotation.y = Random.Range(1, 10);
        rotation.z = Random.Range(1, 10);


    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(bloodSpray, gameObject.transform.position, rotation);
        }


        if (shotTimer <= 0)
        {
            DropSpikeBalls();
            shotTimer = 2;
        }
        shotTimer -= Time.deltaTime;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && player.GetStomp())
        {
            TakeDamage(player.GetDamage());
        }
        else if (collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
            knockBackPosition.x = gameObject.transform.position.x + 10;
            knockBackPosition.y = gameObject.transform.position.y + 10;
            player.GetComponent<Rigidbody>().AddExplosionForce(5, knockBackPosition, 100, 50, ForceMode.Impulse);
        }
        else if (collision.gameObject.tag == "Sword")
        {
            bloodSplash.Play();
            TakeDamage(player.GetDamage());

        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.fillAmount = health / startingHealth;
    }
    public void DropSpikeBalls()
    {
        Instantiate(spikeBall, leftBallSpawn.transform.position, transform.rotation, gameObject.transform);
        Instantiate(spikeBall, middleBallSpawn.transform.position, transform.rotation, gameObject.transform);
        Instantiate(spikeBall, rightBallSpawn.transform.position, gameObject.transform.rotation,gameObject.transform);

    }
    public float GetShotDuration()
    {
        return shotDuration;
    }
}
