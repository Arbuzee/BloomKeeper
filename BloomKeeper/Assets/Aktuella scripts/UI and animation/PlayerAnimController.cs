using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private PlayerPhysics player;
    private Animator anim;

    [SerializeField] AudioSource audioSource;

    [SerializeField] private AudioClip[] jumpSounds;
    [SerializeField] private AudioClip[] decoySounds;
    [SerializeField] private AudioClip[] walkSounds;
    [SerializeField] private AudioClip[] idleSounds;
    [SerializeField] private AudioClip[] hurtSounds;

    private int jumpSoundsIndex;
    private int decoySoundsIndex;
    private int walkSoundsIndex;
    private int idleSoundsIndex;
    private int hurtSoundsIndex;

    private float idleTimer;
    private float idleTimeBetweenVoicelines = 10f;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
        float left_right = Input.GetAxis("Horizontal");
        float bwd_fwd = Input.GetAxis("Vertical");

        anim.SetFloat("left_right", left_right);
        anim.SetFloat("bwd_fwd", bwd_fwd);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("decoy");
            PlayDecoySound();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayJumpSound();
        }

        if (player.PlayerVelocity.x == 0 && player.PlayerVelocity.z == 0)
        {
            if (idleTimer > idleTimeBetweenVoicelines)
            {
                idleTimer = 0;
                PlayIdleSound();

            }
            else
            {
                idleTimer += Time.deltaTime;
            }
        } else
        {
            idleTimer = 0;
        }
        
    }

    public void StandOnPad()
    {
        anim.SetTrigger("pressurepad");
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    private void PlayJumpSound()
    {
        if (jumpSoundsIndex < jumpSounds.Length - 1)
        {
            jumpSoundsIndex++;
        }
        else
        {
            jumpSoundsIndex = 0;
        }
        audioSource.volume = 0.3f;
        PlaySound(jumpSounds[jumpSoundsIndex]);
        
    }

    private void PlayIdleSound()
    {
        if (idleSoundsIndex < idleSounds.Length - 1)
        {
            idleSoundsIndex++;
        }
        else
        {
            idleSoundsIndex = 0;
        }
        audioSource.volume = 1f;
        PlaySound(idleSounds[idleSoundsIndex]);
    }

    private void PlayDecoySound()
    {
        if (decoySoundsIndex < decoySounds.Length - 1)
        {
            decoySoundsIndex++;
        }
        else
        {
            decoySoundsIndex = 0;
        }
        audioSource.volume = 1f;
        PlaySound(decoySounds[decoySoundsIndex]);
    }

    public void PlayHurtSound()
    {
        if (hurtSoundsIndex < hurtSounds.Length - 1)
        {
            hurtSoundsIndex++;
        }
        else
        {
            hurtSoundsIndex = 0;
        }
        audioSource.volume = 0.3f;
        PlaySound(hurtSounds[hurtSoundsIndex]);
    }
}
