using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class INOUT : MonoBehaviour {
		
		/// <summary>
		/// The active1.
		/// </summary>
		bool active1 = false;
		/// <summary>
		/// The active2.
		/// </summary>
		bool active2 = true;
		/// <summary>
		/// The image.
		/// </summary>
		public Image image;
		/// <summary>
		/// The movements.
		/// </summary>
		Hashtable movements = iTween.Hash("z",20.0f,"looptype",iTween.LoopType.pingPong,"time",65f);
		/// <summary>
		/// The movements2.
		/// </summary>
		Hashtable movements2 = iTween.Hash("z",35.0f,"looptype",iTween.LoopType.pingPong,"time",0.45); 
	
	// Use this for initialization
	void Start ()
		{
				if (image != null) {
					//	image.rectTransform.rotation (0f, 0f, 15f, Space.World);
						image.rectTransform.Rotate(0f,0f,-10f,Space.World);
				}
	}
	
	// Update is called once per frame
	void Update () {
				InOut(image,0.5f);
				PINGPONG(image,false);
	}

	/// <summary>
		/// I the specified Text and scale_factor.
		/// </summary>
		/// <param name="Text">Text.</param>
		/// <param name="scale_factor">Scale factor.</param>
		public void IN (Image Text,float scale_factor)
		{
				if (!active1)
					if(Text.rectTransform.localScale.x < .8 || Text.rectTransform.localScale.y < .8 || Text.rectTransform.localScale.z < .8)
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
		public void OUT (Image Text,float scale_factor)
		{
				if (!active2)
					if(Text.rectTransform.localScale.x > 0.5 || Text.rectTransform.localScale.y > 0.5 || Text.rectTransform.localScale.z > .5)
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
		public void InOut(Image Text, float scale_factor)
		{
				IN(Text,scale_factor);
				OUT(Text,scale_factor);
		}
		
		public void PINGPONG (Image Text, bool reverse)
		{
				if (!reverse) {
						iTween.RotateTo(Text.gameObject,movements);
				} 
				else{
						iTween.RotateTo(Text.gameObject,movements2);
				}
		}
}
