
using Assets.Scripts.Event_System.Actions;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ActionBehaviour), true)]
public class ActionBehaviourEditor : Editor
{

    private ActionBehaviour _actionBehaviour;
    public override void OnInspectorGUI()
    {
        _actionBehaviour = (ActionBehaviour)target;
        if (Application.isPlaying)
        {
            if (GUILayout.Button("Trigger Now"))
            {
                _actionBehaviour.DoAction();
            }
        }

        DrawDefaultInspector();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
