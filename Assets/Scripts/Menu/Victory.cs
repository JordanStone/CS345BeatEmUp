using UnityEngine;
using System.Collections;

	public class Victory : MonoBehaviour {

	private Texture dummy; 	//Doesn't actually need to be initialized. 
							//Just needs to attempt to load a texture and fail.

	void OnGUI(){

		if (GUI.Button (new Rect(0,0, Screen.width, Screen.height),dummy, "")){
			Application.LoadLevel("MainMenu");	
		}

	}
}
