using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameState : MonoBehaviour {
      
    public Text HUD_points_disp;
	public Text HUD_time_disp;
	public Text HUD_NEW_RECORD;
	public GameObject HUD_Panel; 
	public static int points {get; set;}
	public static float GameTime {get; set;}	
	public static bool isDead{get; set;}

	// Use this for initialization
	void Start ()
		{
				GameTime = Time.time;
				if (HUD_points_disp != null) {
						HUD_points_disp.text = points.ToString ();
				}
				if (HUD_time_disp != null) {
						HUD_time_disp.text = "Time: "+(GameTime).ToString()+"s";
				if(HUD_Panel !=null)
								HUD_Panel.SetActive(false);
						if(HUD_NEW_RECORD !=null)
								HUD_NEW_RECORD.text = "Time: 00:00:000";
		}
	}
	
	/// <summary>
	/// Updaters this instance.
	/// </summary>
	public void Updaters ()
	{
				float elapseTime = Time.time - GameTime;
			int minutes = Mathf.FloorToInt(elapseTime/60f);
				int secs = Mathf.FloorToInt(elapseTime%60f);
				int fraction = Mathf.FloorToInt(elapseTime*100)%100;
				string text = string.Format("{0:00}:{1:00}:{2:000}",minutes,secs,fraction);
			if (!isDead) {
					HUD_points_disp.text = points.ToString ();
					HUD_time_disp.text = "Time: "+text+"s";
			}else{
				EndGame();
			}
	}


	// Update is called once per frame
	void Update () {
		
		Updaters();	

	}

	/// <summary>
	/// Ends the game.
	/// </summary>
	public void EndGame()
	{
		HUD_NEW_RECORD.text = HUD_time_disp.text;
		HUD_Panel.SetActive(true);
	}

	/// <summary>
	/// Games the state retry.
	/// </summary>
	public void GameStateRetry()
	{
		HUD_Panel.SetActive(false);
		HUD_points_disp.text = "0";
		HUD_time_disp.text = "Time: 0:00:000";
		isDead = false;
		Application.LoadLevel("Felix_Scene");
		
	}	

		public void GameStateMainMenu ()
	{
		Application.LoadLevel("Main Menu");
	}
}
