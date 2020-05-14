using UnityEngine;
using System.Collections;

public class Plasma : MonoBehaviour {
	[HideInInspector]public GameObject[] explosion;
	[HideInInspector]public float speed;
	[HideInInspector]public float life;
	private float dLife;
	private Vector3 prevPosition;
	
	
	void Start(){dLife = life;}
	
	void Update () {
		//if(dLife<0){Destroy(this.gameObject);
		//}else{dLife -= Time.deltaTime;}
		
		//prevPosition = transform.position;
		transform.Translate(Vector3.forward*10*Time.deltaTime);
		
		//float distance = Vector3.Distance(prevPosition, transform.position);
		//RaycastHit hit;
	    //if (Physics.Raycast(prevPosition, transform.forward, out hit, distance) && (hit.transform.gameObject != gameObject)){
		//	int i = (int)Mathf.Round(Random.Range(0, explosion.Length));
		//	GameObject inst = (GameObject)Instantiate(explosion[i], hit.point, transform.rotation);//Quaternion.Euler(0,0,0));
			//Explode explode = inst.GetComponent<Explode>();
			//explode.target = hit.transform;
			//explode.dPosition = hit.transform.position - hit.point;
		//	Destroy(this.gameObject);						
		//}
	}
}
