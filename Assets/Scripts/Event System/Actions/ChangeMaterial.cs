using UnityEngine;
using System.Collections;
using Assets.Scripts.Event_System.Actions;
[RequireComponent(typeof(Renderer))]
public class ChangeMaterial : ActionBehaviour
{
    public Material MaterialToChangeTo;
    private Renderer _renderer;
	// Use this for initialization
    public override void OnStart()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null || MaterialToChangeTo == null)
        {
            Debug.LogError("ChangeMaterial - something is null!");
        }
    }

    public override void OnUpdate()
    {

    }

    public override void DoAction()
    {
        _renderer.material = MaterialToChangeTo;
    }
}
