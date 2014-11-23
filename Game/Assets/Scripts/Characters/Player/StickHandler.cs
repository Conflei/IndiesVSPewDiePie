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
	[Range(2f,3f)]
	public float stickMaxLength = 2f;
	[Range(0.5f,0.7f)]
	public float stickMinLength = 0.5f;
	
	void Start()
	{
		StickLength = stickMinLength;
	}
	
	public void Enlarge()
	{
		float step = Mathf.Abs(stickMinLength - stickMaxLength)/2f;
		StickLength += step * Time.deltaTime;
		if(StickLength > stickMaxLength)
			StickLength = stickMaxLength;
	}
	
	public void Shorten()
	{
		float step = Mathf.Abs(stickMinLength - stickMaxLength)/2f;
		StickLength -= step * Time.deltaTime;
		if(StickLength < stickMinLength)
			StickLength = stickMinLength;
	}
}
