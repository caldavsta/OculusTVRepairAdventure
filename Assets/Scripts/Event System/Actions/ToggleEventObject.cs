using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;


[RequireComponent(typeof(EventObject))]
class ToggleEventObject : ActionBehaviour
{
    private EventObject _eventObject;
    public override void OnStart()
    {
        _eventObject = GetComponent<EventObject>();
    }

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        _eventObject.enabled = !_eventObject.enabled;
    }
}
