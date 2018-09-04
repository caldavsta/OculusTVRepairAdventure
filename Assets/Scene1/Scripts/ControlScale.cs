using UnityEngine;
using System.Collections;

public class ControlScale : MonoBehaviour
{
    public float ScaleOfThisObject;
	// Use this for initialization
	void Start ()
	{
	    ScaleOfThisObject = gameObject.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    gameObject.transform.localScale = new Vector3(ScaleOfThisObject,ScaleOfThisObject, ScaleOfThisObject);
	}
}
