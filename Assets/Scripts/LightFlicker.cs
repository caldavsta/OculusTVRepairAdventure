using UnityEngine;
using System.Collections;

//Didnt end up using this script. Seems to cause lighting ending to redraw too much. Should have researched how others have done a candle flicker effect
[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{

    public float FlickerAmount = 0.03f;
    public float FlickerLength = 0.05f;
    public float FlickerFrequencySecondsMin = 0.03f;
    public float FlickerFrequencySecondsMax = 10f;

    
    private Light _lightComponent;
    private float _defaultRange;
    private bool _flickering = false;

	// Use this for initialization
	void Start ()
	{
	    _lightComponent = GetComponent<Light>();
	    _defaultRange = _lightComponent.range;
	    StartFlicker();

	}
	
	// Update is called once per frame
	void Update () {
	    if (!_flickering)
	    {
	        StartFlicker();
	    }
	}

    void StartFlicker()
    {
        _flickering = true;
        //call FlickerDim after random seconds
        Invoke("FlickerDim", RandomFlickerDelay());
    }

    void FlickerDim()
    {
        _lightComponent.range -= FlickerAmount;
        Invoke("FlickerReset", FlickerLength);
    }

    void FlickerReset()
    {
        _lightComponent.range = _defaultRange;
        _flickering = false;
    }

    float RandomFlickerDelay()
    {
        return Random.Range(FlickerFrequencySecondsMin, FlickerFrequencySecondsMax);
    }

}
