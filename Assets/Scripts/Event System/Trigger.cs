using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Event_System
{
    [System.Serializable]
    public class Trigger : System.Object
    {
        public String Name = "Trigger";
        public enum AndOr { And, Or}

        public AndOr ConditionLogic;
        [SerializeField]
        public Condition[] Conditions;

        [SerializeField] public Action[] Actions;

        
        [HideInInspector] public bool IsWaiting = false;
        private int _currentActionBeingPerformed = 0;

        [HideInInspector] public bool HasBeenTriggered;

        public bool IsTriggered()
        {
            if (HasBeenTriggered) return true;
            bool result;
            if (ConditionLogic == AndOr.And)
            {//the trigger is set to And
                result = true;
                for (int i = 0; i < Conditions.Length; i++)
                {
                    if (!Conditions[i].IsComplete())
                    {
                        result = false;
                    }
                }
            }
            else
            { //the trigger is set to Or
                result = false;
                for (int i = 0; i < Conditions.Length; i++)
                {
                    if (Conditions[i].IsComplete())
                    {
                        result = true;
                        //break;
                    }
                }
            }
            HasBeenTriggered = result;
            return result;
        }

        //returns true if actions are complete. false otherwise
        public bool PerformActions()
        {
            if (!IsWaiting)
            {
                try
                {
                    Actions[_currentActionBeingPerformed].DoAction();
                    _currentActionBeingPerformed++;
                }
                catch (IndexOutOfRangeException ie)
                {
                    return true;
                }

            }

            return false;
        }

    }
}
