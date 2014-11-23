using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FirstCutscene(){
		StartCoroutine (FCWorker ());
	}

	public IEnumerator FCWorker(){
		Camera.main.GetComponent<CameraFollow> ().enabled = false;
		yield return null;
	}
}
