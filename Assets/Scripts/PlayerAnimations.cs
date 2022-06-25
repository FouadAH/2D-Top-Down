using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public ParticleSystem dustParticleSystem;
    public AudioSource footstepAudio;

    public void PlayDustParticles()
    {
        dustParticleSystem.Play();
    }

    public void PlayFootstepAudio()
    {
        footstepAudio.Play();
    }
}

