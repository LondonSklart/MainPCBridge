using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMage : MonoBehaviour
{

    PlayerController player;
    public GameObject magicMissile;
    public GameObject bloodSpray;
    public string direction;
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
        if (shotTimer < 0 && direction == "Left")
        {
            ShootMagicMissile("Left");
            shotTimer = 2;
        }
        if (shotTimer < 0 && direction == "Right")
        {
            ShootMagicMissile("Right");
            shotTimer = 2;
        }
        if (shotTimer < 0 && direction == "Both")
        {
            if (player != null)
            {


                if (gameObject.transform.position.x > player.transform.position.x)
                {
                    ShootMagicMissile("Left");
                }
                if (gameObject.transform.position.x < player.transform.position.x)
                {
                    ShootMagicMissile("Right");
                }
            }
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
    public void ShootMagicMissile(string direction)
    {
        if (direction == "Left")
        {
            shotRotation.z = 0;
        }
        else
        {
            shotRotation.z = 180;
        }

        Instantiate(magicMissile,gameObject.transform.position,shotRotation,gameObject.transform);
    }
    public float GetShotDuration()
    {
        return shotDuration;
    }
}
