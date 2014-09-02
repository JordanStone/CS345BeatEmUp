
using UnityEngine;
using System.Collections;

	public class Pause : MonoBehaviour {

		public Texture menu;
		public Texture resumeButton;
		public Texture menuButton;
		public Texture exitButton;

		public float nativeVerticalRes = 1200.0f;

		private bool isPaused = false;

		void Update(){
			if (Input.GetButtonDown("Pause")){
				if(!isPaused){ //For Pausing
					print("Paused!");
					Time.timeScale = 0.0f;
					isPaused = true;
					AudioListener.pause = true;
				}else{ //For Unpausing
					print("Unpaused!");
					Time.timeScale = 1.0f;
					isPaused = false;
					AudioListener.pause = false;
				}
			}
		}

		void OnGUI(){
			
			if(isPaused){
				GUI.DrawTexture (new Rect ((Screen.width/2)-(Screen.width/4), 0, Screen.width/2, Screen.height/2), menu);

				if (GUI.Button (new Rect((Screen.width/2) - 40f, (Screen.height/2) - 120f, Screen.width/4,Screen.height/4),resumeButton, "")){
					print("Unpaused!");
					Time.timeScale = 1.0f;
					isPaused = false;
					AudioListener.pause = false;
				}

				if (GUI.Button (new Rect((Screen.width/2) - 25f, (Screen.height/2) + 245f, Screen.width/4,Screen.height/4),exitButton, "")){
					Application.Quit();
				}

				if (GUI.Button (new Rect((Screen.width/2) + 25f, (Screen.height/2) + 67f, Screen.width/4,Screen.height/4),menuButton, "")){
					//Make sure you unpause first!
					print("Unpaused!");
					Time.timeScale = 1.0f;
					isPaused = false;
					AudioListener.pause = false;

					Application.LoadLevel("MainMenu");
				}
			}
		}

	}