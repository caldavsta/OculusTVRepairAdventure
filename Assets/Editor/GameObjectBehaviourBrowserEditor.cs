
using Assets.Scripts.Event_System.Actions;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameObjectBehaviourBrowser))]
public class GameObjectBehaviourBrowserEditor : Editor
{
    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
