using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class SoundListener : MonoBehaviour
    {

        AudioSource audiosource;
        void Start()
        {
            SoundEvent.RegisterListener(OnSound);
            audiosource = GetComponent<AudioSource>();

        }

        void OnDestroy()
        {
            SoundEvent.UnregisterListener(OnSound);
        }

        void OnSound(SoundEvent soundPlay)
        {
            Debug.Log("SoundisPlaying");
            audiosource.PlayOneShot(soundPlay.sound);
        }
    }
}

