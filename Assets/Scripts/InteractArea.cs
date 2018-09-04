using System;
using UnityEngine;
using System.Collections;

public class InteractArea : MonoBehaviour
{


    [SerializeField]
    private GameObject podiumLight;
    [SerializeField] private AudioSource lightSwitchAudio;
    [SerializeField] private GameObject indicator;
    private Boolean _playerNearby = false;

    // Use this for initialization
    void Start () {
        if (indicator == null)
        {
            Debug.LogError("indicator gameobject is null. disabling.");
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (PlayerMovement.CheckIfPlayer(collider))
        {
            _playerNearby = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (PlayerMovement.CheckIfPlayer(collider))
        {
            _playerNearby = false;
        }
    }

    // Update is called once per frame
    void Update () {
	    indicator.SetActive(_playerNearby);

        if (_playerNearby)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!lightSwitchAudio.isPlaying) lightSwitchAudio.Play();
                podiumLight.SetActive(true);
            }
        }

	}
}
