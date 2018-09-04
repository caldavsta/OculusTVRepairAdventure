using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour
{
    private MovieTexture movieTexture;
	// Use this for initialization
	void Start ()
	{
	    movieTexture = (MovieTexture) GetComponent<Renderer>().material.mainTexture;
	    movieTexture.loop = true;
        movieTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
