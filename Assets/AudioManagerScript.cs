using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    // Start is called before the first frame update
    [SerializeField] AudioSource sfxSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Paddle;
    public AudioClip Score;
    public AudioClip Win;
    public AudioClip Wall;

    public void playSFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayPaddle()
    {
        sfxSource.PlayOneShot(Paddle);
    }
    public void PlayScore()
    {
        sfxSource.PlayOneShot(Score);
    }
    public void PlayWin()
    {
        sfxSource.PlayOneShot(Win);
    }
    public void PlayWall()
    {
        sfxSource.PlayOneShot(Wall);
    }
}
