using UnityEngine;
using System.Collections;

public class ArmRotator : MonoBehaviour 
{
	public float rotationSpeed = 500;
	public Character character;
	public HingeJoint2D joint;
	
	private float newRotation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		JointMotor2D aux = joint.motor;
		//transform.position = joint.connectedBody.transform.position;
		aux.motorSpeed = newRotation;
		joint.motor = aux;
		newRotation = 0.0f;
	}
	
	public void RotateRight()
	{
		newRotation = rotationSpeed;
	}
	
	public void RotateLeft()
	{
		newRotation = -rotationSpeed;
	}
}
