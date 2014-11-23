using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class popup_message : MonoBehaviour {
	
		/// <summary>
		/// The Canvas.
		/// </summary>
		public Canvas _center_of_canvas;
		
		public enum Animation_For_Text 
		{
		IN_OUT = 0,
		IN = 1,
		OUT = 2,
		PINGPONG = 3,
		SPIN = 4,
		SPINSCALE = 5,
		};
			
		public static Animation_For_Text Type_Animation;
		/// <summary>
		/// Array of texts, Something.
		/// </summary>
		
		
		public enum Angle_Of_Rotation
		{
		XAxis =0,
		YAxis =1,
		ZAxis =2,
		};

		/// <summary>
		/// The angle.
		/// </summary>
		public static Angle_Of_Rotation Angle;
	
		/// <summary>
		/// The size of the letter.
		/// </summary>
		public int LetterSize =40;
		
		/// <summary>
		/// The rotation factor.
		/// </summary>
		public float RotationFactor = 15;

		/// <summary>
		/// The scale factor use for IN,OUT,INOUT,SPINSCALE.
		/// </summary>
		public float scale_factor;
		
		/// <summary>
		/// The rotate factor use for ROTATE.
		/// </summary>
		public float rotate_factor;

		/// <summary>
		/// The interval.
		/// </summary>
		public float interval;

		/// <summary>
		/// The default font.
		/// </summary>
		public Font DefaultFont;	

		/// <summary>
		/// Atributos de cada texto por separador.
		/// </summary>
		[System.Serializable]
		public struct Atribs
		{
				public Font DefaultFont;
				public bool isActive;
				public string Text_Content;
				public int LetterSize;
				public float scale_factor;
				public float rotate_factor;
				public Angle_Of_Rotation rotation;
				public Animation_For_Text animation;
		};
		
		
		public Atribs [] ActiveTextsAtribs;
	
		/// <summary>
		/// The active1.
		/// </summary>
		private bool active1 = false;
		
		/// <summary>
		/// The active2.
		/// </summary>
		private bool active2 = true;

		/// <summary>
		/// The rotate1.
		/// </summary>
		private bool Rotate1 = false;

		/// <summary>
		/// The rotate2.
		/// </summary>
		private bool Rotate2 = false;
		
		/// <summary>
		/// The movements.
		/// </summary>
		Hashtable movements = iTween.Hash("z",-35.0f,"looptype",iTween.LoopType.pingPong,"time",0.45);
		/// <summary>
		/// The movements2.
		/// </summary>
		Hashtable movements2 = iTween.Hash("z",35.0f,"looptype",iTween.LoopType.pingPong,"time",0.45); 
	
		public	Text [] something;		
	
		// Use this for initialization
		void Start ()
		{
					if (gameObject.GetComponent<Canvas> () != null) {
							_center_of_canvas = gameObject.GetComponent<Canvas> ();
					}
					interval = 1f / something.Length;
					Active();

		}
		
		/// <summary>
		/// Active this instance.
		/// </summary>
		public void Active ()
		{
				if (ActiveTextsAtribs.Length == 0 || ActiveTextsAtribs == null) {
						ActiveTextsAtribs = new Atribs[9];
						for (int i = 0; i < 9; i++) {
								ActiveTextsAtribs [i].isActive = true;
								ActiveTextsAtribs [i].LetterSize = LetterSize;
								ActiveTextsAtribs [i].rotate_factor = 0;
								ActiveTextsAtribs [i].scale_factor = 0;
								something [i].gameObject.SetActive (ActiveTextsAtribs [i].isActive);
								something [i].text = ActiveTextsAtribs[i].Text_Content;
						}
				} else 
				{
						for (int i = 0; i < 9; i++) {
								ActiveTextsAtribs[i].DefaultFont = DefaultFont;
								ActiveTextsAtribs [i].LetterSize = LetterSize;
								something [i].gameObject.SetActive (ActiveTextsAtribs [i].isActive);
								something [i].text = ActiveTextsAtribs[i].Text_Content;
								something [i].font = ActiveTextsAtribs[i].DefaultFont;
								something[i].rectTransform.Rotate(0,0,ActiveTextsAtribs[i].rotate_factor,Space.World);
						}
				}
		}	 
		
		/// <summary>
		/// Actualize this instance.
		/// </summary>
		public void Actualize ()
		{
				for (int i = 0; i < 9; i++) {
						something [i].gameObject.SetActive (ActiveTextsAtribs [i].isActive);
						something[i].fontSize = ActiveTextsAtribs [i].LetterSize;
						something[i].text = ActiveTextsAtribs[i].Text_Content;
						something[i].font = ActiveTextsAtribs[i].DefaultFont;
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				Actualize ();
				int random = Mathf.FloorToInt (Time.time / interval);
				random = Mathf.FloorToInt (Random.Range (0, 9));
							
				for (int i = 0; i < 9; i++) {
						if (ActiveTextsAtribs [i].isActive) {
								ActiveAnimation(something[i],ActiveTextsAtribs[i]);
						}
				}
					
	
		}

		/// <summary>
		/// Animates the text.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="type">Type.</param>
		public void Animate_Text (Text Text, Animation_For_Text type)
		{		
			//	int random = Mathf.FloorToInt (Time.time / interval);
			//	Text.rectTransform.Rotate (0,0,Time.deltaTime*random,Space.World);
				//Debug.Log(Text.rectTransform.right+" "+Text.rectTransform);
				//IN(Text,5f);
				//OUT(Text,5f);
				//SPIN(Text,Angle= Angle_Of_Rotation.ZAxis,-5f);
				//INOUT(Text,7f);
				//SPINSCALE(Text,Angle= Angle_Of_Rotation.XAxis,.5f);
				PINGPONG(Text,false);
		}

		public void ActiveAnimation (Text Text, Atribs atributos)
		{
				Debug.Log(atributos.animation);
				switch (atributos.animation) {
					case Animation_For_Text.IN:
						IN(Text,atributos.scale_factor);
					break;
				case Animation_For_Text.OUT:
						OUT(Text,atributos.scale_factor);
					break;
				case Animation_For_Text.IN_OUT:
						INOUT(Text,atributos.scale_factor);
					break;
				case Animation_For_Text.PINGPONG:
						PINGPONG(Text,false);
					break;
				case Animation_For_Text.SPIN:
						SPIN(Text,atributos.rotation,atributos.rotate_factor);
					break;
				case Animation_For_Text.SPINSCALE:
						SPINSCALE(Text,atributos.rotation,atributos.scale_factor);
					break;
				}
		}

		/// <summary>
		/// I the specified Text and scale_factor.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="scale_factor">Scale factor.</param>
		public void IN (Text Text,float scale_factor)
		{
				if (!active1)
					if(Text.rectTransform.localScale.x < 4 || Text.rectTransform.localScale.y < 4 || Text.rectTransform.localScale.z < 4)
							Text.rectTransform.localScale = new Vector3(Text.rectTransform.localScale.x+Time.deltaTime*scale_factor,Text.rectTransform.localScale.y+Time.deltaTime*scale_factor,Text.rectTransform.localScale.z+Time.deltaTime*scale_factor);
					else {
						active1 = true;
						active2 = false;
					}
				else
						return;
		}
				
		/// <summary>
		/// OU the specified Text and scale_factor.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="scale_factor">Scale factor.</param>
		public void OUT (Text Text,float scale_factor)
		{
				if (!active2)
					if(Text.rectTransform.localScale.x > 1 || Text.rectTransform.localScale.y > 1 || Text.rectTransform.localScale.z > 1)
							Text.rectTransform.localScale = new Vector3(Text.rectTransform.localScale.x-Time.deltaTime*scale_factor,Text.rectTransform.localScale.y-Time.deltaTime*scale_factor,Text.rectTransform.localScale.z-Time.deltaTime*scale_factor);
					else {
						active1 = false;
						active2 = true;
					}
				else
						return;
		}
		
		/// <summary>
		/// INOU the specified Text and scale_factor.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="scale_factor">Scale factor.</param>
		public void INOUT (Text Text, float scale_factor)
		{
				IN(Text,scale_factor);
				OUT(Text,scale_factor);
		}
		
		/// <summary>
		/// SPI the specified Text, Type and rotate_factor.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="Type">Type.</param>
		/// <param name="rotate_factor">Rotate factor.</param>
		public void SPIN (Text Text, Angle_Of_Rotation Type, float rotate_factor)
		{
				switch (Type) {
				case Angle_Of_Rotation.XAxis:
						Text.rectTransform.Rotate(rotate_factor,0,0,Space.World);
						break;
				case Angle_Of_Rotation.YAxis:
						Text.rectTransform.Rotate(0,rotate_factor,0,Space.World);
						break;
				case Angle_Of_Rotation.ZAxis:
						Text.rectTransform.Rotate(0,0,rotate_factor,Space.World);
						break;
				}
		}

		/// <summary>
		/// SPINSCAL the specified Text, Type and scale_factor.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="Type">Type.</param>
		/// <param name="scale_factor">Scale factor.</param>
		public void SPINSCALE (Text Text, Angle_Of_Rotation Type, float scale_factor)
		{
				switch (Type) {
				case Angle_Of_Rotation.XAxis:
						if (!Rotate1) {
								if (Text.rectTransform.localScale.x > -1.2)
										Text.rectTransform.localScale = new Vector3 (Text.rectTransform.localScale.x - Time.deltaTime * scale_factor, Text.rectTransform.localScale.y, Text.rectTransform.localScale.z);
								else
										Rotate1 = true;
						} else {
								if (Text.rectTransform.localScale.x < 1.2)
										Text.rectTransform.localScale = new Vector3 (Text.rectTransform.localScale.x + Time.deltaTime * scale_factor, Text.rectTransform.localScale.y, Text.rectTransform.localScale.z);
								else
										Rotate1 = false;
						}
						break;
				case Angle_Of_Rotation.YAxis:
						if (!Rotate1) {
								if (Text.rectTransform.localScale.y > -1.2)
										Text.rectTransform.localScale = new Vector3 (Text.rectTransform.localScale.x , Text.rectTransform.localScale.y- Time.deltaTime * scale_factor, Text.rectTransform.localScale.z);
								else
										Rotate1 = true;
						} else {
								if (Text.rectTransform.localScale.y < 1.2)
										Text.rectTransform.localScale = new Vector3 (Text.rectTransform.localScale.x , Text.rectTransform.localScale.y+ Time.deltaTime * scale_factor, Text.rectTransform.localScale.z);
								else
										Rotate1 = false;
						}break;
				case Angle_Of_Rotation.ZAxis:
						if (!Rotate1) {
								if (Text.rectTransform.localScale.z > -1.2)
										Text.rectTransform.localScale = new Vector3 (Text.rectTransform.localScale.x , Text.rectTransform.localScale.y, Text.rectTransform.localScale.z - Time.deltaTime * scale_factor);
								else
										Rotate1 = true;
						} else {
								if (Text.rectTransform.localScale.z < 1.2)
										Text.rectTransform.localScale = new Vector3 (Text.rectTransform.localScale.x , Text.rectTransform.localScale.y, Text.rectTransform.localScale.z + Time.deltaTime * scale_factor);
								else
										Rotate1 = false;
						}break;
				}
		}

		/// <summary>
		/// PINGPON the specified Text and reverse.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="reverse">If set to <c>true</c> reverse.</param>
		public void PINGPONG (Text Text, bool reverse)
		{
				if (!reverse) {
						iTween.RotateTo(Text.gameObject,movements);
				} 
				else{
						iTween.RotateTo(Text.gameObject,movements2);
				}
		}
		

}
