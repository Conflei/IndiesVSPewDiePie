﻿using UnityEngine;
using System.Collections;

public class ArmRotator : MonoBehaviour 
{
	public float rotationSpeed;
	public Character character;
	
	private float newRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 lookAtVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		lookAtVector.z = 0f;
		float angle = Mathf.Atan2(lookAtVector.y, lookAtVector.x  * (character.FacingRight ? 1 : -1)) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	
	public void RotateRight()
	{
		//newRotation = -rotationSpeed;
	}
	
	public void RotateLeft()
	{
		//newRotation = rotationSpeed;
	}
}
