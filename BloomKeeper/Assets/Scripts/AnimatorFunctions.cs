using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    public bool disableOnce;

    void PlaySound(AudioClip clip)
    {
        if (!disableOnce)
        {
            menuButtonController.audioSource.PlayOneShot(clip);
        }
        else
        {
            disableOnce = false;
        }
    }
}
