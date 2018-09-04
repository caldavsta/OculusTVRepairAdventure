using System;
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static Boolean CheckIfPlayer(Collider collider)
    {
        if (collider.GetComponent<PlayerMovement>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
