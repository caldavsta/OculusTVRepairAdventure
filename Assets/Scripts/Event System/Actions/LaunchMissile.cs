using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;


class LaunchMissile : ActionBehaviour
{
    public GameObject MissilePrefab;

    public override void OnStart()
    {
        if (MissilePrefab == null)
        {
            Debug.LogError("Missile Prefab Not Set!");
        }
    }

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        GameObject clone = (GameObject)Instantiate(MissilePrefab, transform.position, transform.rotation);
    }
}

