using UnityEngine;
using System.Collections;

public class ShortLivedObject : MonoBehaviour {
	public float maxLifeTime;
	private float lifeTime = 0f;
	public GameObject explosionPrefab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		removeAfterTime ();
	}

	void removeAfterTime() {
		if(lifeTime > maxLifeTime)
		{
			Destroy(this.gameObject);
		}
	}
	
}
