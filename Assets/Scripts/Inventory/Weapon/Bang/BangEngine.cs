using UnityEngine;
using System.Collections;

public class BangEngine : MonoBehaviour {
	public float brightness;
	public GameObject plume;
	[HideInInspector]public float speed;
	[HideInInspector]public float speedMax;
	[HideInInspector]public ParticleSystem particleSysEngine;
	[HideInInspector]public float startSize = 1.0f;
	
	private AudioSource audioEngine;
	private LensFlare lensFlare;	
	private float startSpeed;

	void Start(){
		audioEngine = GetComponent<AudioSource>();
		lensFlare = GetComponent<LensFlare>();	
		if(plume){
			plume = (GameObject)Instantiate(plume, transform.position, transform.rotation);
			TrailRenderer trailRenderer = plume.GetComponent<TrailRenderer>();
			trailRenderer.startWidth = trailRenderer.startWidth*startSize;
			trailRenderer.endWidth = trailRenderer.endWidth*startSize;
		}
		particleSysEngine = GetComponent<ParticleSystem>();
		//startSpeed = particleSysEngine.startSpeed;
		//startSize = particleSysEngine.startSize*startSize;
        lensFlare.brightness = 10000;
        particleSysEngine.Play();
        if (plume) { plume.transform.position = transform.position;}
    }
	
	void Update () {
        if (plume) { plume.transform.position = transform.position; }
        lensFlare.brightness = brightness;
    }
}
