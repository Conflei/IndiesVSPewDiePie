using UnityEngine;
using System.Collections;

public class BaseInput : MonoBehaviour
{
	public Character targetCharacter;

	void Update()
	{
		InputPicker();
	}

	/// <summary>
	/// Picks the input function that can be called based on the targetCharacter current movement state.
	/// </summary>
	public virtual void InputPicker()
	{
		if(targetCharacter != null)
		{		
			WalkInput();
			if(targetCharacter.CurrentMovementState == Character.MovementState.Idle ||
			   targetCharacter.CurrentMovementState == Character.MovementState.Walking)
				JumpInput();
		}
	}

	/// <summary>
	/// Handle walking input
	/// </summary>
	public virtual void WalkInput()
	{

	}

	/// <summary>
	/// Handle jumping input
	/// </summary>
	public virtual void JumpInput()
	{

	}

	/// <summary>
	/// Handle action input
	/// </summary>
	public virtual void ActionInput()
	{

	}
}