using UnityEngine;
using System.Collections;
using Assets.Scripts.Event_System;
using Assets.Scripts.Event_System.Actions;

public class KillDragon : ActionBehaviour
{

    public SplineWalker SplineWalker;
    public Animation Animation;
    public DragonBreatheFire DragonBreatheFire;
    public ParticleSystem ParticleSystemToDisable;
    public string AnimationName;
    


	// Use this for initialization
    public override void OnStart()
    {
        if (ParticleSystemToDisable == null)
        {
            Debug.LogError("ParticleSystemToDisable is NULL!");
        }
    }

    /*
    public new void OnTriggerEnter(Collider c)
    {
        Debug.Log("HIT! " + c.gameObject.name);
        if (c.gameObject.GetComponent<Missile>() != null)
        {
            DoAction();
        }
    }
    */

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        Debug.Log("KillDragon: Killing Dragon");
        ParticleSystem.EmissionModule ps = ParticleSystemToDisable.emission;
        ps.enabled = false;

        DragonBreatheFire.Disable();

        SplineWalker.enabled = false;
        Animation.Play(AnimationName);
    }
}
