using UnityEngine;
using System.Collections;

public class PlayerInput : BaseInput
{
	public ArmRotator arm;
	public StickHandler stick;

	public override void InputPicker ()
	{
		base.InputPicker ();
		if(Input.GetKey(KeyCode.Q))
		{
			arm.RotateLeft();
		}
		else if(Input.GetKey(KeyCode.E))
		{
			arm.RotateRight();
		}
		else if(Input.GetKey(KeyCode.R))
		{
			stick.Enlarge();
		}
		else if(Input.GetKey(KeyCode.F))
		{
			stick.Shorten();
		}
	}

	public override void WalkInput()
	{
		targetCharacter.Walk(Input.GetAxis("Horizontal"));
	}

	public override void JumpInput()
	{
		if(Input.GetButtonDown("Jump"))
			targetCharacter.Jump();
	}
}