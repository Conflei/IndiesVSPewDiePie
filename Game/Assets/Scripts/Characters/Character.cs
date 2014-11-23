using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController2D))]
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
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	public float jumpHeight = 3f;
	
	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;
	
	protected CharacterController2D controller;
	public bool FacingRight
	{
		get
		{
			return Mathf.Sign(transform.localScale.x) == 1;
		}
	}
	private Animator animator;
	private RaycastHit2D lastControllerColliderHit;
	private Vector3 velocity;
	private float horizontal;
	private float vertical;
	
	void Awake()
	{
		animator = GetComponent<Animator>();
		controller = GetComponent<CharacterController2D>();
		
		// listen to some events for illustration purposes
		controller.onControllerCollidedEvent += onControllerCollider;
		controller.onTriggerEnterEvent += onTriggerEnterEvent;
		controller.onTriggerExitEvent += onTriggerExitEvent;
	}
	
	
	#region Event Listeners
	
	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;
		
		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}
	
	
	void onTriggerEnterEvent( Collider2D col )
	{
		Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
	}
	
	
	void onTriggerExitEvent( Collider2D col )
	{
		Debug.Log( "onTriggerExitEvent: " + col.gameObject.name );
	}
	
	#endregion
	
	public virtual void UpdateMovementState()
	{
	
	}
	
	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{
		// grab our current _velocity to use as a base for all calculations
		velocity = controller.velocity;
		
		if( controller.isGrounded )
			velocity.y = 0;
		
		if( normalizedHorizontalSpeed == 1 )
		{
			if( transform.localScale.x < 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
		else if( normalizedHorizontalSpeed == -1 )
		{
			if( transform.localScale.x > 0f )
				transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, transform.localScale.z );
		}
		
		
		// we can only jump whilst grounded
		/*if( controller.isGrounded && Input.GetKeyDown( KeyCode.UpArrow ) )
		{
			velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
		}*/
		
		
		// apply horizontal speed smoothing it
		var smoothedMovementFactor = controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		velocity.x = Mathf.Lerp( velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );
		
		// apply gravity before moving
		velocity.y += gravity * Time.deltaTime;
		
		controller.move( velocity * Time.deltaTime );
	}
	

	/// <summary>
	/// Walk function that is in charge of making the character move.
	/// </summary>
	/// <param name="horizontal">Horizontal.</param>
	/// <param name="vertical">Vertical.</param>
	public virtual void Walk(float horizontal, float vertical = 0f)
	{
		if(Mathf.Approximately(horizontal, 0))
			normalizedHorizontalSpeed = 0;
		else
			normalizedHorizontalSpeed = Mathf.Sign(horizontal);
	}

	/// <summary>
	/// Jump function.
	/// </summary>
	public virtual void Jump()
	{
		//velocity.y = Mathf.Sqrt( 2f * jumpHeight * -gravity );
		float horizontalMovement = Mathf.Lerp( velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime);
		controller.move((Vector3.right * horizontalMovement + Vector3.up * Mathf.Sqrt( 2f * jumpHeight * -gravity)) * Time.deltaTime);
	}
	
	public virtual void Kill()
	{
		Camera.main.GetComponent<CameraFX>().CameraShake();
		Destroy (gameObject);
	}
}