using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EventManager))]
public class EventManagerEditor : Editor
{
    private bool _showFoldoutNewTrigger = true;
    private bool _showFoldoutDeleteTrigger = false;
    private bool _showFoldoutInGameControls = true;
    private EventManager myScript;
    private int _currentInsertIndex;
    private int _currentDeleteIndex;

    public override void OnInspectorGUI()
    {
        myScript = (EventManager)target;

        DrawDefaultInspector();


        _showFoldoutNewTrigger = EditorGUILayout.Foldout(_showFoldoutNewTrigger, "Insert Trigger");
        if (_showFoldoutNewTrigger)
        {
            DrawNewTriggerArea();
        }

        _showFoldoutDeleteTrigger = EditorGUILayout.Foldout(_showFoldoutDeleteTrigger, "Delete Trigger");
        if (_showFoldoutDeleteTrigger)
        {
            DrawDeleteTriggerArea();
        }

        _showFoldoutInGameControls = EditorGUILayout.Foldout(_showFoldoutInGameControls, "In-Game Controls");
        if (_showFoldoutInGameControls)
        {
            DrawInGameControls();
        }
        

    }

    private void DrawNewTriggerArea()
    {
        GUILayout.BeginHorizontal(GUIStyle.none);
        EditorGUILayout.LabelField("Index:");
        _currentInsertIndex = EditorGUILayout.IntField(_currentInsertIndex);
        if (GUILayout.Button("Insert"))
        {
            myScript.InsertTriggerAt(_currentInsertIndex);
            myScript.NewTrigger = null;
            _currentInsertIndex = myScript.Triggers.Count - 1;
        }
        GUILayout.EndHorizontal();
    }

    private void DrawDeleteTriggerArea()
    {
        GUILayout.BeginHorizontal(GUIStyle.none);
        EditorGUILayout.LabelField("Index:");
        _currentDeleteIndex = EditorGUILayout.IntField(_currentDeleteIndex);
        if (GUILayout.Button("Delete"))
        {
            myScript.RemovetTriggerAt(_currentDeleteIndex);
            myScript.NewTrigger = null;
            _showFoldoutDeleteTrigger = false;
            _currentDeleteIndex = myScript.Triggers.Count - 1;
        }
        GUILayout.EndHorizontal();
    }

    private void DrawInGameControls()
    {
        GUILayout.Label("Current Event: " + myScript.CurrentTriggerIndex + ": " + myScript.Triggers[myScript.CurrentTriggerIndex].Name);

        if (GUILayout.Button("Next Event"))
        {
            myScript.NextEvent();
        }
        if (GUILayout.Button("Previous Event"))
        {
            myScript.PreviousEvent();
        }
    }

}
