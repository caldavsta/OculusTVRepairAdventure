using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundOnCollision : MonoBehaviour {

    public AudioClip Sound;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Sound;
    }

    void OnCollisionEnter() 
    {
        GetComponent<AudioSource>().Play();
    }
}
