using UnityEngine;
using System.Collections;

public class Master : MonoBehaviour {

	// Use this for initialization
	public void Awake(){
		GameController.FX.FadeIn (GameController.FX.whiteColor, 0.01f);
	}

	public IEnumerator Start () {

		yield return new WaitForSeconds (1f);
		GameController.FX.FadeOut (2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
