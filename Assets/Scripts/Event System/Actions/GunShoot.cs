using UnityEngine;
using System.Collections;
using Assets.Scripts.Event_System.Actions;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class GunShoot : ActionBehaviour
{

    public float ShootForce = 15;
	// Use this for initialization
    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {

    }


    public override void DoAction()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.right * ShootForce, ForceMode.Impulse);
        GetComponent<AudioSource>().Play();
        Debug.Log("Gun Shot!");
    }
}
