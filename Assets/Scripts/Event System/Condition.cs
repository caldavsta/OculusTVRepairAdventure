using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Event_System
{
    [System.Serializable]
    public class Condition : System.Object
    {
        public enum ConfiguredButtons { ResetOculusView, Interact }
        public enum ConditionType { NarrationComplete, PlayerLookAt, ButtonPressed, LevelStart };
        
        public String Name = "Unnamed Condition";
        public ConditionType Type;

        public bool OneShot = false;
        private bool _hasBeenCompleted = false;

        public GameObject LookTargetOptional;
        public ConfiguredButtons ButtonOptional;
        private EventManager _eventManager;



        public bool IsComplete()
        {

            //Setup eventmanager for first use
            if (_eventManager == null)
            {
                _eventManager = GameObject.Find(EventManager.NAME).GetComponent<EventManager>();
            }

            //begin checking the condition
            bool result = false;
            if (_eventManager == null)
            {
                Debug.LogError("Condition || Cant find EventManager.");
                Debug.Break();
            }
            else
            {
                if (!OneShot || !_hasBeenCompleted)
                {
                    switch (Type)
                    {
                        case ConditionType.LevelStart:
                            result = true;
                            break;
                        case ConditionType.PlayerLookAt:
                            if (VerifyLookTargetSet())
                            {
                                if (_eventManager.EventActor.CurrentlyLookingAt == LookTargetOptional)
                                {
                                    result = true;
                                    _hasBeenCompleted = true;
                                }
                            }
                            break;
                        case ConditionType.NarrationComplete:
                            if (!_eventManager.NarrationAudioSource.isPlaying)
                            {
                                result = true;
                            }
                            break;
                        case ConditionType.ButtonPressed:
                            String whichButton = "";
                            if (ButtonOptional == ConfiguredButtons.Interact) whichButton = "Interact";
                            if (ButtonOptional == ConfiguredButtons.ResetOculusView) whichButton = "OculusResetView";
                            if (Input.GetButtonDown(whichButton))
                            {
                                result = true;
                            }
                            break;
                    }
                }
                else
                {
                    result = true;
                }
            }
            
            return result;
        }

        private bool VerifyLookTargetSet()
        {
            if (LookTargetOptional == null)
            {
                Debug.Log("ConditionType set to LookTarget but no Target was found.");
                Debug.Break();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
