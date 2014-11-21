using UnityEngine;
using System.Collections;

public class PlayerInput : BaseInput
{
	public override void WalkInput()
	{
		targetCharacter.Walk(Input.GetAxis("Horizontal"));
	}

	public override void JumpInput()
	{
		if(Input.GetButtonDown("Jump"))
			targetCharacter.Jump();
	}

	public override void ActionInput()
	{

	}
}