﻿using UnityEngine;
using System.Collections;

public class UIManagerScrip : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame()
	{
				AutoFade.LoadLevel("Felix_Scene",2f,2f,Color.white);
	}	
}
