using UnityEngine;
using System.Collections;

public class TipHandler : MonoBehaviour 
{
	public Character myCharacter;

	void OnTriggerEnter2D(Collider2D other)
	{
		Character otherChar = other.GetComponent<Character>();
		if(otherChar != null)
		{
			if(myCharacter != otherChar)
				otherChar.Kill();
		}
	}
}
