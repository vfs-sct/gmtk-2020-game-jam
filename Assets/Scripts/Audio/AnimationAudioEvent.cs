using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAudioEvent : MonoBehaviour {

    public AudioSourceController footstepSound;

    public void PlayFootstepAudio()
    {
        footstepSound.PlayImmediately();
    }
}
