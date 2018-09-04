using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]
class ToggleSteamRelease : ActionBehaviour
{

    public AudioClip SteamSound;

    private bool _steamReleasing = false;
    private AudioSource _audioSource;
    private ParticleSystem.EmissionModule _particleSystem;


    public override void OnStart()
    {
        _audioSource = GetComponent<AudioSource>();
        _particleSystem = GetComponent<ParticleSystem>().emission;
        _audioSource.clip = SteamSound;
        SetSteamRelease(false);
    }

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        SetSteamRelease(!_steamReleasing);
    }

    private void SetSteamRelease(bool state)
    {
        _steamReleasing = state;

        if (state)
        {
            _audioSource.Play();
            _particleSystem.enabled = true;
        }
        else
        {
            _audioSource.Stop();
            _particleSystem.enabled = false;
        }

    }
}
