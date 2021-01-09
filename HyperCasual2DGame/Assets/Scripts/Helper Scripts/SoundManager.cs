using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;
   /* [SerializeField]
    private AudioSource music;*/

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip;
   
    void Awake()
    {
        if (instance == null)
            instance = this;

    }

    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

   /* public void playMusic()
    {
        music.Play();
    }

    public void stopMusic()
    {
        music.Stop();
    }*/
}
