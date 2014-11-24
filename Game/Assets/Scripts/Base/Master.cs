using UnityEngine;
using System.Collections;

public class Master : MonoBehaviour {

	// Use this for initialization
	public void Awake(){
		Camera.main.GetComponent<CameraFX>().FadeIn (Camera.main.GetComponent<CameraFX>().whiteColor, 0.01f);
	}

	public IEnumerator Start () {

		yield return new WaitForSeconds (1f);
		Camera.main.GetComponent<CameraFX>().FadeOut (2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
