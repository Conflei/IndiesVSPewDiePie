using UnityEngine;
using System.Collections;

public class AudioHandler : MonoBehaviour{

	public AudioClip[] audios;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		source = this.GetComponent<AudioSource> ();
	}
	
	public void PlayEnlarge(){
		source.clip = audios [0];
		source.Play ();
	}
	

	public void PlayShorten(){
		source.clip = audios [1];
		source.Play ();
	}

	public void PlayDeath(){
		source.clip = audios [2];
		source.Play ();
	}

	public void PlayJump(){
		source.clip = audios [3];
		source.Play ();
	}
}
