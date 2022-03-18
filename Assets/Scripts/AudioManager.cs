using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager obj;

    public AudioClip jump;
    public AudioClip heroHit;
    public AudioClip coin;
    public AudioClip enemy;
    public AudioClip win;
   
    public AudioClip gui;

    private AudioSource audioSrc;

    void Awake()
    {
        audioSrc = gameObject.AddComponent<AudioSource>();
        obj = this;
    }

    public void PlayJump() { playSound(jump); }
    public void PlayHeroHit() { playSound(heroHit); }
    public void PlayCoin() { playSound(coin); }
    public void PlayEnemy() { playSound(enemy); }
    public void PlayWin() { playSound(win); }
    public void PlayGui() { playSound(gui); }


    public void playSound(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }

     void OnDestroy()
    {
        obj = null;
    }
}
