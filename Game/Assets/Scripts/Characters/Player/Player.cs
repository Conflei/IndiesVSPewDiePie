using UnityEngine;
using System.Collections;


public class Player : Character
{

	public override void UpdateMovementState()
	{
		if(controller.isGrounded)
		{
			if(Mathf.Approximately(controller.velocity.x,0f))
				CurrentMovementState = MovementState.Idle;
			else
				CurrentMovementState = MovementState.Walking;
		}
		else
		{
			if(controller.velocity.y < 0)
				CurrentMovementState = MovementState.Falling;
		}
	}
}