using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    Roguelike-Shooter v1.0
Developer:  nihar
Company:    DeadW0Lf Games
Date:       14-03-2023 13:32:58
================================================*/ 
[RequireComponent(typeof(AudioSource))]
public abstract class AudioPlayer : MonoBehaviour {

    protected AudioSource audioSource;
    protected float basePitch;
    [SerializeField] protected float pitchRandomness = 0.05f;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        basePitch = audioSource.pitch;
    }

    protected void PlayClipWithVariablePitch(AudioClip clip) {
        var randomPitch = Random.Range(-pitchRandomness, pitchRandomness);
        audioSource.pitch = basePitch + randomPitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip) {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

}