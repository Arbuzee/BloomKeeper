using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;
    private AudioSource audioSource;


    public void PlaySound(AudioClip audioClip)
    {

        audioSource.PlayOneShot(audioClip);

    }

    public void Awake()
    {

        //Setup singleton
        if (instance == null)
            instance = this;

        if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }
}
