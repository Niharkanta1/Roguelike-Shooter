using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       14-03-2023 13:38:18
================================================*/ 
public class GameMusicPlayer : AudioPlayer {
    [SerializeField]
    private AudioClip levelMusicClip, gameOverMusicClip, victoryMusicClip;

    public void PlayLevelMusic(int levelIndex) => PlayClip(levelMusicClip);
    public void PlayGameOverMusic() => PlayClip(gameOverMusicClip);
    public void PlayVictoryMusic() => PlayClip(victoryMusicClip);
}