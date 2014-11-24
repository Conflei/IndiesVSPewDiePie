using UnityEngine;
using System.Collections;


public class Player : Character
{

	public override void UpdateMovementState()
	{
		if(controller.isGrounded)
		{
			if(Mathf.Abs(controller.velocity.x) <= 0.1f)
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
	public override void Kill ()
	{
				if (Dead) return;
				Dead = true;
		GameController.FX.ToGray();
				GameState.isDead = true;
				gameObject.GetComponent<PlayerInput>().enabled = false;
	}
}