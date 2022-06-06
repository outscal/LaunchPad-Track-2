using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip death;
    public AudioClip click;
    public AudioClip win;

    public AudioSource source;

    public void PlayWin()
	{
        source.clip = win;
        source.Play();
    }

    public void PlayDeath()
	{
        source.clip = death;
        source.Play();
    }

    public void PlayClick()
	{
        source.clip = click;
        source.Play();
	}
}
