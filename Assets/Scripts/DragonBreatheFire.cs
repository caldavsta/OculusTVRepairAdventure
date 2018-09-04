using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Comparers;

public class DragonBreatheFire : MonoBehaviour
{

    public ParticleSystem[] ParticlesToEnable;
    public Animation[] AnimationsToEnable;
    public AudioSource AudioSourceToEnable;
    [Header("Frequency")] public float RandomDelaySecondsMin;
    public float RandomDelaySecondsMax;
    public float DurationSeconds;
    private bool _waitingToBreatheFire = false;
    private bool _breathingFire = false;
    private bool _canBreatheFire = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (!_waitingToBreatheFire && !_breathingFire)
	    {
	        StartCoroutine(WaitToBreatheFire());
	    }
	}

    public void Disable()
    {
        _canBreatheFire = false;
        //BreatheFire(false);
        //enabled = false;
        Debug.Log("Disabling Breathing fire _canBreatheFire:" + _canBreatheFire);
    }

    IEnumerator WaitToBreatheFire()
    {
        _waitingToBreatheFire = true;
        float randomDelay = Random.Range(RandomDelaySecondsMin, RandomDelaySecondsMax);
        yield return new WaitForSeconds(randomDelay);
        _waitingToBreatheFire = false;
        BreatheFire(true);
    }

    private void BreatheFire(bool on)
    {
        if (_canBreatheFire || on == false)
        {
            _breathingFire = on;

            //audio
            AudioSourceToEnable.enabled = on;

            //particle systems
            foreach (ParticleSystem thisParticleSystem in ParticlesToEnable)
            {
                ParticleSystem.EmissionModule pse = thisParticleSystem.emission;
                pse.enabled = on;
            }

            //animation
            foreach (Animation thisAnimation in AnimationsToEnable)
            {
                if (on)
                {
                    thisAnimation.Play();
                }
                else
                {
                    thisAnimation.Stop();
                }
            }



            //coroutine
            if (on)
            {
                StartCoroutine(WaitToStopBreathingFire());
            }

        }
    }

    IEnumerator WaitToStopBreathingFire()
    {
        yield return new WaitForSeconds(DurationSeconds);
       
        BreatheFire(false);

    }
    
}
