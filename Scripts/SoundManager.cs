using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, scoreSound, deadSound ;
    static AudioSource myMusic;

    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("Jump");
        scoreSound = Resources.Load<AudioClip>("Score");
        deadSound = Resources.Load<AudioClip>("Dead");

        myMusic = GetComponent<AudioSource>();
    }


    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                myMusic.PlayOneShot(jumpSound);
                break;
            case "Score":
                myMusic.PlayOneShot(scoreSound);
                break;
            case "Dead":
                myMusic.PlayOneShot(deadSound);
                break;
        }
    }
}
