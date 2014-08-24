/// <summary>
/// Game Over.
/// Attached to Main Camera
/// </summary>

using UnityEngine;
using System.Collections;

	public class GameOver : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture PlayAgainButton;
	public Texture ExitButton;

	void OnGUI(){

//		SoundController playsound = gameObject.GetComponent<SoundController>();

		//Display background texture
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		//Display buttons

		if (GUI.Button (new Rect((Screen.width/2) + 60f, (Screen.height/2) - 115f, 201,191),PlayAgainButton, "")){
//			playsound.PlayMerge();
			Application.LoadLevel("SceneOne");	
		}

		if (GUI.Button (new Rect((Screen.width/2) + 100f, (Screen.height/2) + 245f, 232,187),ExitButton, "")){
			Application.Quit();
		}

	}
}
