using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Event_System.Actions;

[ExecuteInEditMode]
public class GameObjectBehaviourBrowser : MonoBehaviour
{
    public GameObject GameObjectToBrowse;
    public ActionBehaviour[] MonoBehaviours;
    private GameObject _previousGameObject;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (_previousGameObject != GameObjectToBrowse)
	    {
	        _previousGameObject = GameObjectToBrowse;
            Debug.Log("GameObjectBehaviourBrowser || Updating actionbehaviour list");
	        MonoBehaviours = GameObjectToBrowse.GetComponents<ActionBehaviour>();
	    }
	}
}
