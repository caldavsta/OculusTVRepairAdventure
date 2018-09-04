using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;

class ToggleGameObject : ActionBehaviour
{
    public GameObject GameObjectToToggle;
    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        GameObjectToToggle.SetActive(!GameObjectToToggle.activeInHierarchy);
    }
}