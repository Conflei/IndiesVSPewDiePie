using UnityEngine;
using System.Collections;

public class PlatformEnemyInput : BaseInput 
{
	public Transform player;
	public float horizontalDetectorOffset;
	public bool platformForward;
	public float jumpToPlayerDistance;
	public LayerMask platformLayer;
	
	void Start()
	{
		player = GameObject.Find("Player").transform;
	}
	
	public override void InputPicker ()
	{
		WalkInput();
		RaycastHit2D hit = Physics2D.Raycast(new Vector3(transform.position.x + horizontalDetectorOffset * Mathf.Sign(transform.localScale.x), transform.localPosition.y), -Vector2.up, 1f, platformLayer);
		float distanceToPlayer = (transform.position - player.position).magnitude;

		if(hit.transform == null || distanceToPlayer  <= jumpToPlayerDistance)
		{
			if(targetCharacter.CurrentMovementState == Character.MovementState.Idle ||
				targetCharacter.CurrentMovementState == Character.MovementState.Walking)
			JumpInput();
		}
	}
	
	public override void WalkInput ()
	{
		float dir = Mathf.Sign(player.position.x - transform.position.x);
		targetCharacter.Walk(dir);
	}
	
	public override void JumpInput ()
	{
		targetCharacter.Jump();
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(new Vector3(transform.position.x + horizontalDetectorOffset * Mathf.Sign(transform.localScale.x), transform.localPosition.y), 
		                new Vector3(transform.position.x + horizontalDetectorOffset * Mathf.Sign(transform.localScale.x), transform.localPosition.y-1));
	}	
}
