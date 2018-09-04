using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {
    public float TurnSpeed = 1.0f;
    public float Speed = 1.0f;
    public string GameObjectNameToTarget;
    public GameObject Explosion;
    private GameObject _gameObjectTarget;
    private bool _hasCollided = false;
	// Use this for initialization
	void Start () {
        _gameObjectTarget = GameObject.Find(GameObjectNameToTarget);
        if (_gameObjectTarget == null)
        {
            Debug.LogError("Cant find gameobject: " + GameObjectNameToTarget);
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {


    }

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Missile Hit " + c.gameObject.name + " _hasCollided: " + _hasCollided);
        if (!_hasCollided)
        {
            _hasCollided = true;
            GameObject.Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
            GameObject.Find("EventManager").GetComponent<EventManager>().NextEvent();
            Destroy(gameObject);
        }

    }

    void FixedUpdate()
    {
        Vector3 pos = _gameObjectTarget.transform.position - transform.position;
        var newRot = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRot, TurnSpeed);

        transform.Translate(Vector3.forward * Speed);

    }
}
