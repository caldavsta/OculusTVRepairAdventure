using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace Assets.Scripts.Event_System
{
    [System.Serializable]
    public class Action : System.Object
    {
        //Serialized Fields
        public String Name = "Unnamed Action";
        public ActionTypes TypeOfAction;
        public AudioClip AudioClipOptional;
        public ActionBehaviour ActionBehaviourOptional;
        public float WaitSecondsOptional;
        [HideInInspector]
        public string MethodNameOptional = "DoAction";

        private ActionBehaviour _actionBehaviour;
        
        public enum ActionTypes { PlayNarration, PlaySound, PlayMusic, RunActionBehaviour, Wait }

        
        public void DoAction()
        {
            switch (TypeOfAction)
            {
                case ActionTypes.PlayNarration:
                    GameObject.Find(EventManager.NAME).GetComponent<EventManager>().NarrationAudioSource.PlayOneShot(AudioClipOptional);
                    break;
                case ActionTypes.PlaySound:
                    GameObject.Find(EventManager.NAME).GetComponent<EventManager>().SoundEffectsAudioSource.PlayOneShot(AudioClipOptional);
                    break;
                case ActionTypes.PlayMusic:
                    GameObject.Find(EventManager.NAME).GetComponent<EventManager>().MusicAudioSource.PlayOneShot(AudioClipOptional);
                    break;

                case ActionTypes.RunActionBehaviour:
                    ExecuteActionBehaviour();
                    break;
                case ActionTypes.Wait:
                    GameObject.Find(EventManager.NAME).GetComponent<EventManager>().DelayEventManager(WaitSecondsOptional);
                    break;
            }
        }


        private void ExecuteActionBehaviour()
        {
            MethodNameOptional = "DoAction";
            if (MethodNameOptional.Equals(""))
            {
                Debug.LogError("Action || Action type is RunMethod but no MethodNameOptional is specified");
            }
            else
            {
                if (ActionBehaviourOptional == null)
                {
                    Debug.LogError("Action || Action type is RunMethod but no GameObject is selected");
                }
                else
                {
                    CallMethodByReflection(MethodNameOptional);
                }
            }
        }


        private void CallMethodByReflection(string methodName)
        {
            //http://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
            //Get the method information using the method info class
            if (_actionBehaviour == null)
            {
                _actionBehaviour = ActionBehaviourOptional;
                if (_actionBehaviour == null)
                {
                    Debug.LogError("Action || No action behaviour found on ActionBehaviourOptional: " + ActionBehaviourOptional.name);
                }
            }
            MethodInfo mi = _actionBehaviour.GetType().GetMethod(methodName);

            mi.Invoke(_actionBehaviour, null);
        }
        
    }
}
