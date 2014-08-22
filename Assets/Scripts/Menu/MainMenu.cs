/// <summary>
/// Main menu.
/// Attached to Main Camera
/// </summary>

using UnityEngine;
using System.Collections;

	public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture PlayButton;
	public Texture TutButton;
	public Texture ExitButton;

	void OnGUI(){

//		SoundController playsound = gameObject.GetComponent<SoundController>();

		//Display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		//Display buttons

		if (GUI.Button (new Rect((Screen.width/2) + 60f, (Screen.height/2) - 115f, 201,191),PlayButton, "")){
//			playsound.PlayMerge();
			Application.LoadLevel("SceneOne");	
		}

		if (GUI.Button (new Rect((Screen.width/2) + 100f, (Screen.height/2) + 245f, 232,187),ExitButton, "")){
			Application.Quit();
		}

		if (GUI.Button (new Rect((Screen.width/2) + 125f, (Screen.height/2) + 67f, 250,183),TutButton, "")){
//			playsound.PlayMerge();
			Application.LoadLevel("tutorial");			
		}

	}
}
