using UnityEngine;
using System.Collections;

public class Character : Entity
{
	public enum MovementState
	{
		Idle,
		Walking,
		Jumping,
		Falling
	}
	private MovementState _currentMovementState;
	public MovementState CurrentMovementState
	{
		get { return _currentMovementState; }
		set
		{
			_currentMovementState = value;
			if(animator != null)
			{
				animator.SetBool("Idle", _currentMovementState == MovementState.Idle);
				animator.SetBool("Walking", _currentMovementState == MovementState.Walking);
				animator.SetBool("Jumping", _currentMovementState == MovementState.Jumping);
				animator.SetBool("Falling", _currentMovementState == MovementState.Falling);
			}
		}
	}

	public Animator animator;

	public float grounderLength;
	[Range(0.5f, 1.0f)]
	public float midAirDamping;
	public float jumpSpeed;
	public float walkSpeed;
	public float maxHorizontalSpeed;
	public LayerMask groundLayer;

	public bool isGrounded;

	void Start()
	{

	}

	/// <summary>
	/// Updates the state of the movement.
	/// </summary>
	public virtual void UpdateMovementState()
	{

	}

	/// <summary>
	/// Checks if the character is grounded.
	/// </summary>
	void CheckGrounded()
	{
		RaycastHit2D rayHit = Physics2D.Raycast(rigidbody2D.position, -Vector2.up, grounderLength, groundLayer);
		if(rayHit != null)
		{
			isGrounded = true;
		}
		else isGrounded = false;
	}

	void Update()
	{
		CheckGrounded();
		UpdateMovementState();
		
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxHorizontalSpeed)
		{
			if(CurrentMovementState == MovementState.Falling || CurrentMovementState == MovementState.Jumping)
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxHorizontalSpeed * midAirDamping, rigidbody2D.velocity.y);
			else
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxHorizontalSpeed, rigidbody2D.velocity.y);
		}
	}

	/// <summary>
	/// Walk function that is in charge of making the character move.
	/// </summary>
	/// <param name="horizontal">Horizontal.</param>
	/// <param name="vertical">Vertical.</param>
	public virtual void Walk(float horizontal, float vertical = 0f)
	{

	}

	/// <summary>
	/// Jump function.
	/// </summary>
	public virtual void Jump()
	{

	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(rigidbody2D.position, -Vector3.up * grounderLength);
	}
}