using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;

[RequireComponent(typeof(Animation))]
class ToggleAnimation : ActionBehaviour
{
    private Animation _animationToToggle;
    public override void OnStart()
    {
        _animationToToggle = GetComponent<Animation>();
    }

    public override void OnUpdate()
    {
    }

    public override void DoAction()
    {
        if (_animationToToggle.isPlaying)
        {
            _animationToToggle.Stop();
        }
        else
        {
            _animationToToggle.Play();
        }
    }
}
