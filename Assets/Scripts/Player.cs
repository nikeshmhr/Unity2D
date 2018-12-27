using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float shakeAmount = 0.1f;
    public float shakeLength = 0.1f;

    private AudioSource audioSource;
    public AudioClip deathClip, landedClip;

    public static Player player;

    public void Awake() {
        // TODO: add safe checks
        if(player == null) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }
    }

    public void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType soundType) {
        if(player.audioSource.volume != 1) {
            player.audioSource.volume = 1;
        }
        switch(soundType) {
            case SoundType.DEATH:
                player.audioSource.clip = player.deathClip;
                break;

            case SoundType.LAND:
                player.audioSource.clip = player.landedClip;
                break;
        }
        player.PlayIt();
    }

    private void PlayIt() {
        player.audioSource.Play();
    }

    public enum SoundType {
        DEATH,
        JUMP,
        WALK,
        LAND
    }

}
