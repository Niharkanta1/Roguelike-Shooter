using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       14-03-2023 13:43:16
================================================*/ 
public class GameSFX : AudioPlayer {
    [SerializeField] private AudioClip[] gameSounds;

    public void PlaySoundEffect(int index)
    {
        PlayClipWithVariablePitch(gameSounds[index]);
    }
}