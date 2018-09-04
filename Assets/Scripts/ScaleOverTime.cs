using UnityEngine;
using System.Collections;

public class ScaleOverTime : MonoBehaviour
{

    public float speed = 1.0f;
    public float speedFactor = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //dop this
	}

    void FixedUpdate()
    {

        speed += speedFactor;
        gameObject.transform.localScale = new Vector3(transform.localScale.x + speed, transform.localScale.y + speed, transform.localScale.z + speed);
        gameObject.transform.position = new Vector3(transform.position.x, transform.localScale.y/2, transform.position.z);
    }
}
