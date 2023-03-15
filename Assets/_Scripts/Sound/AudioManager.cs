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

    [SerializeField] private bool playMusic;
    [SerializeField] private GameMusicPlayer gameMusicPlayer;
    [SerializeField] private GameSFX gameSfx;
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(playMusic)
            PlayLevelMusic();
    }

    private void PlayLevelMusic() => gameMusicPlayer.PlayLevelMusic(1);
    public void PlayGameOver() => gameMusicPlayer.PlayGameOverMusic();
    public void PlayWinMusic() => gameMusicPlayer.PlayVictoryMusic();
    public void PlaySound(int index) => gameSfx.PlaySoundEffect(index);
}