﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public bool running = false;

    PlayerController player;

    public AudioSource runningSound;
    public AudioSource playerDeath;
    public AudioSource mainTheme;
    public Sound[] sounds;

    public AudioSource[] getHitSounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;

        }
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        player = FindObjectOfType<PlayerController>();
    }

    public void Update()
    {

        if (running == true && player.GetGrounded())
        {
            if (runningSound.isPlaying == false)
            {
                runningSound.Play();
            }
        }
        else
        {
            runningSound.Stop();
        }

    }
    public void StartTheme()
    {
        mainTheme.Play();
    }
    public void GetHitSound()
    {
        int randomNumber = Random.Range(0,getHitSounds.Length);
        getHitSounds[randomNumber].Play();
    }
    public void PlayDeathSound()
    {
        foreach (AudioSource a in gameObject.GetComponents<AudioSource>())
        {
            a.Stop();
        }
        running = false;
        playerDeath.Play();

    }
}
