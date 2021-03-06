﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GreaterEnemy : MonoBehaviour
{

    PlayerController player;
    public GameObject bloodSpray;
    public float damage = 2;
    public float startingHealth = 10;
    private float currentPatrol = 0;
    public float patrolAreaSize = 100;
    string direction = "Left";
    private float health;
    public float scoreValue;
    Vector3 knockBackPosition;
    Quaternion rotation;

    public AudioSource hitSound;

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
            Manager.Instance.IncreaseScore(scoreValue);

            Destroy(gameObject);
            Instantiate(bloodSpray, gameObject.transform.position, rotation);
        }
        if (currentPatrol > patrolAreaSize)
        {
            SwappingDirection();
            currentPatrol = 0;
        }

        Patroling(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
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
        hitSound.Play();
        health -= damage;
        healthbar.fillAmount = health / startingHealth;
    }
    public void Patroling(string direction)
    {
        int directionalInput = -1;
        if (direction == "Left")
        {
            directionalInput = -1;
            currentPatrol++;
        }
        else
        {
            directionalInput = 1;
            currentPatrol++;
        }

        gameObject.transform.Translate(directionalInput * Time.deltaTime, 0, 0);
    }
    public void SwappingDirection()
    {
        if (direction == "Left")
        {
            direction = "Right";
        }
        else
        {
            direction = "Left";
        }
    }
}

