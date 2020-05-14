using UnityEngine;
using System.Collections;

public class EmitterDel : MonoBehaviour {
	private ParticleSystem particleSys;
	
	void Start(){
		particleSys = GetComponent<ParticleSystem>();
	}
	
	void Update () {
		if(particleSys.IsAlive()==false){Destroy(this.gameObject);}	
	}
}
