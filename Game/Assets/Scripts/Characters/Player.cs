using UnityEngine;
using System.Collections;


public class Player : Character
{
	public override void UpdateMovementState()
	{
		if(isGrounded)
		{
			if(Mathf.Approximately(rigidbody2D.velocity.x,0f))
				CurrentMovementState = MovementState.Idle;
			else
				CurrentMovementState = MovementState.Walking;
		}
		else
		{
			if(rigidbody2D.velocity.y < 0)
				CurrentMovementState = MovementState.Falling;
		}
	}

	public override void Walk(float horizontal, float vertical = 0f)
	{
		if(!isGrounded)
			rigidbody2D.AddForce(Vector2.right * horizontal * walkSpeed * midAirDamping);
		else 
			rigidbody2D.AddForce(Vector2.right * horizontal * walkSpeed);

		if(Mathf.Abs(rigidbody2D.velocity.x) > maxHorizontalSpeed)
			rigidbody2D.velocity = 
				new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxHorizontalSpeed, rigidbody2D.velocity.y);
	}

	public override void Jump()
	{
		if(isGrounded && CurrentMovementState != MovementState.Jumping)
		{
			rigidbody2D.AddForce(Vector2.up * jumpSpeed);
			CurrentMovementState = MovementState.Jumping;
		}
	}
}