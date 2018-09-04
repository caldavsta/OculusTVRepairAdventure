using UnityEngine;
using System.Collections;
using Assets.Scripts.Event_System.Actions;

[RequireComponent(typeof(AudioSource))]
public class PlayAudio : ActionBehaviour
{

    public AudioClip AudioClip;

    private AudioSource _audioSource;

	// Use this for initialization
    public override void OnStart()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void OnUpdate()
    {

    }
    
    public override void DoAction()
    {
        _audioSource.PlayOneShot(AudioClip);
    }
}
