using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Event_System.Actions;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
class SlamPictureFrame : ActionBehaviour
{
    public AudioClip SlamSound;
    public float SlamForce = 10;
    public override void OnStart()
    {
        GetComponent<Rigidbody>().Sleep();
    }

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        GetComponent<AudioSource>().PlayOneShot(SlamSound);
        GetComponent<Rigidbody>().WakeUp();
        GetComponent<Rigidbody>().AddExplosionForce(SlamForce, transform.position - Vector3.up - Vector3.left, 10.0f);
    }
    }
