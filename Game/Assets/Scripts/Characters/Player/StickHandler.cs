using UnityEngine;
using System.Collections;

public class StickHandler : MonoBehaviour 
{
	private float _stickLength;
	public float StickLength
	{
		get { return _stickLength; }
		set
		{
			_stickLength = value;
			transform.localScale = new Vector3(_stickLength, transform.localScale.y);
		}
	}
	[Range(5f,20f)]
	public float stickMaxLength = 2f;
	[Range(0.5f,0.7f)]
	public float stickMinLength = 0.5f;
	
	public bool onCooldown;
	
	void Start()
	{
		StickLength = stickMinLength;
	}
	
	IEnumerator EnlargeRoutine()
	{
		GameController.FX.CameraShake ();
		GameController.Sounds.PlayEnlarge ();
		onCooldown = true;
		float step = Mathf.Abs(stickMinLength - stickMaxLength) * 5f;
		while(StickLength < stickMaxLength)
		{
			StickLength += step * Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		
		step = Mathf.Abs(stickMinLength - stickMaxLength)/2f;
		while(StickLength > stickMinLength)
		{
			StickLength -= step * Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		StickLength = stickMinLength;
		onCooldown = false;
	}
	
	public void Enlarge()
	{
//		float step = Mathf.Abs(stickMinLength - stickMaxLength) * 5f;
//		StickLength += step * Time.deltaTime;
//		if(StickLength > stickMaxLength)
//			StickLength = stickMaxLength;
		if(!onCooldown)
			StartCoroutine(EnlargeRoutine());
	}
	
	public void Shorten()
	{
		float step = Mathf.Abs(stickMinLength - stickMaxLength)/2f;
		StickLength -= step * Time.deltaTime;
		if(StickLength < stickMinLength)
			StickLength = stickMinLength;
		StartCoroutine (PlayShorten ());
	}

	public IEnumerator PlayShorten(){
		yield return new WaitForSeconds (.5f);
		GameController.Sounds.PlayShorten ();
	}
}
