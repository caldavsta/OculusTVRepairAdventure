using UnityEngine;
using System.Collections;
using System.Reflection;

[RequireComponent(typeof(AudioSource))]
public class EventActor : MonoBehaviour {
    
    public AudioClip AudioBeginLookingAt;
    public AudioClip AudioStopLookingAt;
    public float MaxLookInteractDistance = 100f;
    public GameObject EventObjectCrosshair;
    private Vector3 _eventObjectCrosshairVector3;
    public AudioClip EventObjectSelectSound;


    private const float EventObjectCrosshairOffset = -0.1f;
    private const float EventObjectCrosshairScale = 0.05f;

    public GameObject CurrentlyLookingAt { get; private set; }

    // Use this for initialization
	void Start ()
	{
	    CurrentlyLookingAt = null;
        _eventObjectCrosshairVector3 = new Vector3(0,0,0);

        CheckForConfigurationErrors();


	}
	
	// Update is called once per frame
	void Update () {
	    //raycast forward
        //if intersect EventObject
            //render a crosshair
	    if (Input.GetButtonDown("Interact"))
	    {
	        if (CurrentlyLookingAt != null)
	        {
	            CallDefaultActionMethodByReflection(CurrentlyLookingAt.GetComponent<EventObject>());
                GetComponent<AudioSource>().PlayOneShot(EventObjectSelectSound);
	        }
	    }
	    PerformRaycastForEventObjects();

	}
    
    void FixedUpdate()
    {

    }

    private void PerformRaycastForEventObjects()
    {
        RaycastHit hit;
        Ray lookRay = new Ray(transform.position, transform.forward * MaxLookInteractDistance);
        Debug.DrawRay(transform.position, transform.forward * MaxLookInteractDistance, Color.red);
        if (Physics.Raycast(lookRay, out hit))
        {
            if (hit.transform.gameObject.GetComponent<EventObject>() != null && hit.transform.gameObject.GetComponent<EventObject>().enabled && hit.distance < MaxLookInteractDistance) // if the hit is an EventObject AND its enabled
            {
                if (CurrentlyLookingAt == null)
                {
                    BeginLookingAt(hit.transform.gameObject, hit);
                }
                else
                {
                    if (CurrentlyLookingAt == hit.transform.gameObject) // if the player wasn't already looking at it
                    {
                        ContinueLookingAt(hit.transform.gameObject, hit);
                    }
                    else
                    {
                        StopLookingAt();
                        BeginLookingAt(hit.transform.gameObject, hit);
                    }
                }

            }
            else
            {
                if (CurrentlyLookingAt != null)
                {
                    StopLookingAt();
                }
            }
        }
        else
        {
            if (CurrentlyLookingAt != null)
            {
                StopLookingAt();
            }

        }
    }

    private void CheckForConfigurationErrors()
    {
        if (EventObjectCrosshair == null)
        {
            Debug.LogError("EventObjectCrosshair");
            Debug.Break();
        }
    }

    private void BeginLookingAt(GameObject gameObjectLookingAt, RaycastHit hit)
    {
        if (CurrentlyLookingAt != null) //if already looking at something
        {
            StopLookingAt();
        }
        //Debug.Log("Player started looking at " + gameObjectLookingAt.name);
        CurrentlyLookingAt = gameObjectLookingAt;
        //GetComponents<AudioSource>()[EventManager.SOUND_EFFECTS_AUDIO_SOURCE_INDEX].PlayOneShot(AudioBeginLookingAt);

        _eventObjectCrosshairVector3.z = hit.distance + EventObjectCrosshairOffset;
        EventObjectCrosshair.transform.localPosition = _eventObjectCrosshairVector3;
        EventObjectCrosshair.transform.localScale = new Vector3(hit.distance * EventObjectCrosshairScale, hit.distance * EventObjectCrosshairScale, 1);
        EventObjectCrosshair.SetActive(true);

    }

    private void ContinueLookingAt(GameObject gameObjectLookingAt, RaycastHit hit)
    {

        _eventObjectCrosshairVector3.z = hit.distance + EventObjectCrosshairOffset;
        EventObjectCrosshair.transform.localPosition = _eventObjectCrosshairVector3;
        EventObjectCrosshair.transform.localScale = new Vector3(hit.distance * EventObjectCrosshairScale, hit.distance * EventObjectCrosshairScale, 1);

    }

    public void StopLookingAt()
    {
        EventObjectCrosshair.SetActive(false);
        //Debug.Log("Player stopped looking at " + CurrentlyLookingAt);
        CurrentlyLookingAt = null;
        //GetComponents<AudioSource>()[EventManager.SOUND_EFFECTS_AUDIO_SOURCE_INDEX].PlayOneShot(AudioStopLookingAt);
    }

    private void CallDefaultActionMethodByReflection(EventObject eventObject)
    {
        //http://stackoverflow.com/questions/540066/calling-a-function-from-a-string-in-c-sharp
        //Get the method information using the method info class
        MethodInfo mi = eventObject.GetType().GetMethod(EventObject.DoInteractActionMethodName);

        //Invoke the method
        // (null- no parameter for the method call
        // or you can pass the array of parameters...)
        mi.Invoke(eventObject, null);
    }
}
