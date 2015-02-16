using UnityEngine;
using System.Collections;

public class Tank : DestrutableObject {
	public GameObject bulletPrefab;
	protected GameObject turret;
	protected GameObject nozzle;
	public Camera camera;
	protected Vector3 targetPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void findNozzleTurret () {
		Transform[] transforms = GetComponentsInChildren<Transform>();
		foreach (Transform t in transforms)
		{
			if(t.gameObject.name == "turret")
			{
				turret = t.gameObject;
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t.gameObject;
			}
		}
	}

	void aimTurret () {
		turret.transform.LookAt( targetPos );
	}

	void reloadTimer () {
		//
	}

	void fireBullet () {
			Quaternion rotation = Quaternion.Euler(Vector3.up * turret.transform.rotation.eulerAngles.y);
			Instantiate(bulletPrefab, nozzle.transform.position, rotation);
	}
}
