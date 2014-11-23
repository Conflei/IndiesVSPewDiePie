using UnityEngine;
using System.Collections;

public class EvilBillyInput : BaseInput 
{
	public float pathLength;
	private Vector2 startingPosition;
	
	void Start()
	{
		startingPosition = transform.position;
	}
	
	public override void InputPicker ()
	{
		WalkInput();
	}
	
	public override void WalkInput ()
	{
		if(transform.position.x > startingPosition.x + pathLength * 0.5f)
			targetCharacter.Walk(-1);
		else if(transform.position.x < startingPosition.x - pathLength * 0.5f)
			targetCharacter.Walk(1);
		else if(targetCharacter.FacingRight)
			targetCharacter.Walk(1);
		else if(!targetCharacter.FacingRight)
			targetCharacter.Walk(-1);
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(new Vector3(startingPosition.x - pathLength * 0.5f, transform.position.y), 
		                new Vector3(startingPosition.x + pathLength * 0.5f, transform.position.y));
	}
}
