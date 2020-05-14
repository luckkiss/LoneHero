using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public float radius;
	public float power;
	public float delayExplosion;
	public float damage;
//	public float size;
	
	[HideInInspector]public Transform target;
	[HideInInspector]public Vector3 dPosition;
	private bool explosionStarted;
	private Collider[] colliders;
	private float delay;
	
	void Update(){
		if (target){transform.position = target.position - dPosition;}
		if (explosionStarted==false){
			if (delay>delayExplosion){
				Vector3 explosionPosition = transform.position; 
				colliders = Physics.OverlapSphere (explosionPosition, radius);
		
				foreach (Collider hit in colliders) {
					if (!hit){continue;}
					
					if (hit.GetComponent<Rigidbody>()){
						hit.GetComponent<Rigidbody>().AddExplosionForce((power), explosionPosition, (radius), 0);
					//	hit.GetComponent<Rigidbody>().AddExplosionForce((power * size), explosionPosition, (radius * size), 0);//(4f * size));							
					}
					hit.gameObject.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);	
					hit.gameObject.SendMessage("PointHit", transform.position, SendMessageOptions.DontRequireReceiver);
				}

				explosionStarted = true;
			}else{delay+=Time.deltaTime;}	
		}
	}
}


