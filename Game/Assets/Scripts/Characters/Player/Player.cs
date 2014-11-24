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
		Camera.main.GetComponent<CameraFX>().ToGray();
				GameState.isDead = true;
                GameObject.Find("Player").GetComponent<PlayerInput>().enabled = false;
                //Time.timeScale = 0f;
	}
}