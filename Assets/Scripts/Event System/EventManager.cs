using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

using Assets.Scripts.Event_System;

public class EventManager : MonoBehaviour
{
    public static string NAME = "EventManager";
    public static int SOUND_EFFECTS_AUDIO_SOURCE_INDEX = 0;
    public static int MUSIC_AUDIO_SOURCE_INDEX = 1;
    [NonSerialized]
    public AudioSource NarrationAudioSource;
    public AudioSource MusicAudioSource;
    public AudioSource SoundEffectsAudioSource { get; private set; }

    public EventActor EventActor;
    private int _currentTriggerIndex = 0;
    public List<Trigger> Triggers; // The list of triggers that appears in the editor
    [Header("Add a New Trigger")]
    [Space(10)]
    public Trigger NewTrigger; // the NEW trigger that appears under the list in the editor

    private bool _waiting;
    // Use this for initialization
    void Start()
    {
        _currentTriggerIndex = 0;
        SoundEffectsAudioSource = EventActor.gameObject.GetComponents<AudioSource>()[SOUND_EFFECTS_AUDIO_SOURCE_INDEX];
        MusicAudioSource = EventActor.gameObject.GetComponents<AudioSource>()[MUSIC_AUDIO_SOURCE_INDEX];
        NarrationAudioSource = GameObject.Find("NARRATION_AUDIO_SOURCE").GetComponent<AudioSource>();
        CheckForConfigurationErrors();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_waiting)
        {
            if (Triggers[_currentTriggerIndex].IsTriggered())
            {
                if (Triggers[_currentTriggerIndex].PerformActions())
                {
                    NextEvent();
                }
            }
        }
    }

    public void NextEvent()
    {
        if (_currentTriggerIndex + 1 < Triggers.Count)
        {
            Debug.Log("Completed Trigger " + Triggers[_currentTriggerIndex].Name);
            _currentTriggerIndex++;
            Debug.Log("Starting Trigger " + Triggers[_currentTriggerIndex].Name);
        }
        else
        {
            Debug.LogWarning("EventManager has reached the end of the trigger list. Disabling", this);
            gameObject.SetActive(false);
        }
    }

    public void PreviousEvent()
    {
        if (_currentTriggerIndex-- >= 0)
        {
            _currentTriggerIndex--;
        }
    }

    public void InsertTriggerAt(int index)
    {
        Triggers.Insert(index, NewTrigger);
    }

    public void RemovetTriggerAt(int index)
    {
        Triggers.RemoveAt(index);
    }

    private void CheckForConfigurationErrors()
    {
        if (NarrationAudioSource == null)
        {
            Debug.LogError("NarrationAudioSource is not set", this);
            Debug.Break();
        }

        if (SoundEffectsAudioSource == null)
        {
            Debug.LogError("SoundEffectsAudioSource is not set", this);
            Debug.Break();
        }

        if (EventActor == null)
        {
            Debug.LogError("EventActor is not set", this);
            Debug.Break();
        }

        if (!gameObject.name.Equals("EventManager"))
        {
            Debug.LogError("EventManager is not named properly. It is named: " + gameObject.name, this);
            Debug.Break();
        }

    }

    public int CurrentTriggerIndex
    {
        get { return _currentTriggerIndex; }
        set { _currentTriggerIndex = value; }
    }

    public void DelayEventManager(float seconds)
    {
        Triggers[CurrentTriggerIndex].IsWaiting = true;
        StartCoroutine(Wait(seconds));
        Debug.Log("Beginning " + seconds + " second wait.");
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Triggers[CurrentTriggerIndex].IsWaiting = false;
        Debug.Log("Done Waiting");
    } 


}