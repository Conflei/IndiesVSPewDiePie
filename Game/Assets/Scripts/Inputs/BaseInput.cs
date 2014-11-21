using UnityEngine;
using System.Collections;

public class BaseInput : MonoBehaviour
{
	public Character targetCharacter;

	void Update()
	{
		InputPicker();
	}

	public virtual void InputPicker()
	{
		if(targetCharacter != null)
		{		
			switch(targetCharacter.CurrentMovementState)
		    {
		    case Character.MovementState.Idle:
		    case Character.MovementState.Walking:
		    case Character.MovementState.Falling:
		        WalkInput();
		        break;
		    case Character.MovementState.Jumping:
		        JumpInput();
		        break;
		    }
		}
	}

	public virtual void WalkInput()
	{

	}

	public virtual void JumpInput()
	{

	}

	public virtual void ActionInput()
	{

	}
}