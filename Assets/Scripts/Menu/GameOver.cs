﻿/// <summary>
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

		if (GUI.Button (new Rect((Screen.width/2) - 200f, (Screen.height/2) - 145f, Screen.width/3,Screen.height/3),PlayAgainButton, "")){
//			playsound.PlayMerge();
			Application.LoadLevel("SceneOne");	
		}

		if (GUI.Button (new Rect((Screen.width/2) + 100f, (Screen.height/2) - 145f, Screen.width/3,Screen.height/3),ExitButton, "")){
			Application.Quit();
		}

	}
}
