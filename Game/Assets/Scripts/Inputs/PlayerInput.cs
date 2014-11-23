using UnityEngine;
using System.Collections;

public class PlayerInput : BaseInput
{
	public ArmRotator arm;
	public StickHandler stick;
	private Vector3 previousMousePosition;

	public override void InputPicker ()
	{
		base.InputPicker ();
		if(MouseMovedLeft())
		{
			arm.RotateLeft();
		}
		else if(MouseMovedRight())
		{
			arm.RotateRight();
		}
		else if(Input.GetMouseButton(0))
		{
			stick.Enlarge();
		}
		else if(Input.GetMouseButton(1))
		{
			stick.Shorten();
		}
		previousMousePosition = Input.mousePosition;
	}

	private bool MouseMovedRight()
	{
		return (previousMousePosition - Input.mousePosition).x < 0;
	}
	
	private bool MouseMovedLeft()
	{
		return (previousMousePosition - Input.mousePosition).x > 0;
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