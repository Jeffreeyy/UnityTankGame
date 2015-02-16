using UnityEngine;
using System.Collections;

public class Explosion : ShortLivedObject {
	public float maxLifeTime;
	private float lifeTime;
	public float lightFade;
	private Light light;
	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		fadeExplosion ();
	}

	void fadeExplosion(){
		light.intensity -= lightFade;
		
		lifeTime += Time.deltaTime;
		if (lifeTime > maxLifeTime)
		{
			Destroy(this.gameObject);
		}
	}
}
