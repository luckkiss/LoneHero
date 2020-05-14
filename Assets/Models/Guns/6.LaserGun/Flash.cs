using UnityEngine;
using System.Collections;

public class Flash : MonoBehaviour {
	[HideInInspector]public float life;
	[HideInInspector]public float lifeAfterOff;
	[HideInInspector]public bool lookAt;
	[HideInInspector]public bool glow;
	[HideInInspector]public bool on;
	private float dLife;
	private Renderer rendererFlash;
	private Color color;

	void Start () {
		rendererFlash = GetComponent<Renderer>();
		color = rendererFlash.material.GetColor("_TintColor");
		if(on==true){dLife = lifeAfterOff;}
	}
	
	void Update () {
		if(lookAt==true){transform.LookAt(Camera.main.transform);}
		if(glow==false){
			if(on==false){
				if(dLife<lifeAfterOff){dLife += Time.deltaTime;}
				else{on=true;}
			}else{
				if(life<0){
					if(dLife<0){Destroy(this.gameObject);
					}else{dLife -= Time.deltaTime;}
				}else{life -= Time.deltaTime;}
			}
				
			rendererFlash.material.SetColor("_TintColor",new Color(color.r,color.g,color.b,dLife/lifeAfterOff));
		}
	}
}
