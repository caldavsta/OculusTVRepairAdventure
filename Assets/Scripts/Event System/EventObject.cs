using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using Assets.Scripts.Event_System.Actions;

public class EventObject : MonoBehaviour
{
    public enum InteractActionEnum
    {
        None,
        ToggleAudioPause,
        PlayAudioOnce,
        RunActionBehaviour
    }

    public const string DoInteractActionMethodName = "DoInteractAction";
    public InteractActionEnum InteractAction;

    public ActionBehaviour ActionBehaviourOptional;

    private bool _audioHasBeenPlayed = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoInteractAction()
    {
        switch (InteractAction)
        {
            case InteractActionEnum.ToggleAudioPause:
                ActionToggleAudioPause();
                break;
            case InteractActionEnum.PlayAudioOnce:
                ActionPlayAudioOnce();
                break;
            case InteractActionEnum.RunActionBehaviour:

                if (ActionBehaviourOptional == null)
                {
                    Debug.LogError(
                        "EventObject || Action Type set to run method but ActionBehaviourOptional is missing");
                }
                else
                {
                    CallActionMethodOnMonoBehaviour();
                }
                break;
        }
        
    }

    void DoAction()
    {

    }


    private AudioSource GetAudioSource()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("EventObject || Action requires audio but cannot Find AudioSource");
            this.enabled = false;
            return null;
        }
        else
        {
            return audioSource;
        }
    }

    private void ActionToggleAudioPause()
    {

        if (GetAudioSource().isPlaying)
        {
            GetAudioSource().Pause();
        }
        else
        {
            GetAudioSource().Play();
        }
    }

    private void ActionPlayAudioOnce()
    {
        if (!_audioHasBeenPlayed)
        {
            GetAudioSource().Play();
            _audioHasBeenPlayed = true;
        }
    }

    private void CallActionMethodOnMonoBehaviour()
    {
        
        //http://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
        //Get the method information using the method info class
        MethodInfo mi = ActionBehaviourOptional.GetType().GetMethod("DoAction");

        //Invoke the method
        // (null- no parameter for the method call
        // or you can pass the array of parameters...)
        try
        {
            mi.Invoke(ActionBehaviourOptional, null);
        }
        catch (NullReferenceException nre)
        {
            Debug.LogError(nre.StackTrace);
            Debug.LogError("Null reference on CallAtionMethodOnMonoBehaviour. Make sure the method you are calling is Public!");
        }
    }
}
