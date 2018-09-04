using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;

class ToggleMonoBehaviour : ActionBehaviour
{
    public MonoBehaviour MonoBehaviourToActivate;
    public override void OnStart()
    {
        if (MonoBehaviourToActivate == null)
        {
            Debug.LogError("ToggleMonoBehaviour on " + gameObject.name + " is null.");
        }
    }

    public override void OnUpdate()
    {
        
    }

    public override void DoAction()
    {
        MonoBehaviourToActivate.enabled = !MonoBehaviourToActivate.enabled;
    }
}
