using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class MultiColorParticles : MonoBehaviour
{
    [SerializeField] private bool RandomizeColors;
    [SerializeField] private Color[] particleColors;
    private ParticleSystem myParticleSystem;
    private ParticleSystem.Particle[] myParticles;

    // Use this for initialization
    void Start ()
	{
        myParticleSystem = GetComponent<ParticleSystem>();
        myParticles = new ParticleSystem.Particle[myParticleSystem.maxParticles];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate()
    {
        for (int i = 0; i < myParticles.Length; i++)
        {
            myParticles[i].startColor = particleColors[Random.Range(0, particleColors.Length)];
        }
        myParticleSystem.SetParticles(myParticles, myParticles.Length);
    }
}
