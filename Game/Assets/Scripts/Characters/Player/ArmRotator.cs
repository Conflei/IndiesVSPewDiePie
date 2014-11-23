using UnityEngine;
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
		//transform.position = joint.connectedBody.transform.position;
		if(character.transform.localScale.x < 1 && character.FacingRight)
			transform.Rotate(Vector3.forward, (newRotation + 180) * Time.deltaTime);
		else
			transform.Rotate(Vector3.forward, newRotation * Time.deltaTime);
		newRotation = 0.0f;
	}
	
	public void RotateRight()
	{
		newRotation = -rotationSpeed;
	}
	
	public void RotateLeft()
	{
		newRotation = rotationSpeed;
	}
}
