using UnityEngine;
using System.Collections;
using Assets.Scripts.Event_System.Actions;


[RequireComponent(typeof(EventObject))]
[RequireComponent(typeof(AudioSource))]
public class MakeTelevisionBreak : ActionBehaviour
{
    public ParticleSystem Sparks;
    public float SparkSecondsMin = 0.0f;
    public float SparkSecondsMax = 5.0f;

    public AudioClip BreakingSound;
    public AudioClip SparkingSound;

    public GameObject TvScreenGameObject;

    public Material BrokenTvScreenMaterial;

    private bool _broken;
    private bool _waitingToSpark;



    // Use this for initialization
    public override void OnStart ()
	{
	    if (BreakingSound == null || SparkingSound == null || Sparks == null || BrokenTvScreenMaterial == null || TvScreenGameObject == null)
	    {
	        Debug.LogError("MakeTelevisionBreak: Either BreakingSound or SparkingSound or Sparks or BrokenTvScreenMaterial or TvScreenGameObject are not set");
	    }
	}
	
	// Update is called once per frame
	public override void OnUpdate() {
	    if (_broken)
	    {
	        if (!_waitingToSpark)
	        {
	            _waitingToSpark = true;
	            StartCoroutine(WaitToMakeSparksFly());
	        }
	    }
	}

    public override void DoAction()
    {
        Debug.Log("Breaking the TV");
        MakeSparksFly();
        _broken = true;
        GetComponent<EventObject>().enabled = false;
        _waitingToSpark = false;
        GetComponent<AudioSource>().PlayOneShot(BreakingSound);
        TvScreenGameObject.GetComponent<Renderer>().material = BrokenTvScreenMaterial;
    }
    

    IEnumerator WaitToMakeSparksFly()
    {
        float timeToWait = Random.Range(SparkSecondsMin, SparkSecondsMax);
        yield return new WaitForSeconds(timeToWait);
        MakeSparksFly();
    }

    void MakeSparksFly()
    {
        Sparks.Emit(8);
        _waitingToSpark = false;
        GetComponent<AudioSource>().PlayOneShot(SparkingSound);
    }
}
