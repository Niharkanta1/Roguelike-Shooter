using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       14-03-2023 10:57:42
================================================*/ 
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource levelMusic, gameOverMusic, winMusic;

    private void Awake()
    {
        instance = this;
    }

    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }
    
    public void PlayWinMusic()
    {
        levelMusic.Stop();
        winMusic.Play();
    }
}