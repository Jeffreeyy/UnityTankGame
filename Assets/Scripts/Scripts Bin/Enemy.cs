﻿using UnityEngine;
using System.Collections;

public class Enemy : Tank {
	private float reloadTime;
	public float timeToReload;
	public GameObject bulletPrefab;
	public float shootingRange;
	private Transform turret;
	private Transform nozzle;
	// Use this for initialization
	void Start () {
		reloadTime = 0;
		
		Transform[] transforms = this.gameObject.GetComponentsInChildren<Transform>();
		foreach(Transform t in transforms)
		{
			if(t.gameObject.name == "turret")
			{
				turret = t;
				
			}
			if(t.gameObject.name == "nozzle")
			{
				nozzle = t;
				
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		reloadTime += Time.deltaTime;
		if(reloadTime >= timeToReload)
		{
			checkIfSeesPlayer();
		}
	}

	void determineTarget() {

	}

	void checkIfSeesPlayer() {
		Ray myRay = new Ray();
		myRay.origin = turret.position;
		myRay.direction = turret.forward;
		
		RaycastHit hitInfo;
		
		
		//checken met behulp van een raycast of de player in zicht is
		if(Physics.Raycast(myRay, out hitInfo, shootingRange))
		{
			print(hitInfo.collider.gameObject.name);
			string hitObjectName = hitInfo.collider.gameObject.name;
			
			if(hitObjectName == "Tank")
			{
				//zo ja schieten en reloadtime weer op 0 zetten
				Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
				
				reloadTime = 0f;
			}
		}
	}
}
