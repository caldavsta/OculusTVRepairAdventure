using UnityEngine;
using System.Collections;

public class MyOculusManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Debug.Log("MyOculusMananger Started");
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetButtonUp("OculusResetView"))
	    {
	        OVRManager.display.RecenterPose();
            Debug.Log("Oculus Orientation has been reset");
	    }
	}
}
