using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class LightAutoOff : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Light>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
