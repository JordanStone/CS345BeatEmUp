
using UnityEngine;
using System.Collections;

	public class Pause : MonoBehaviour {

		public GUISkin guiSkin;
		public Texture test;
		public float nativeVerticalRes = 1200.0f;

		private bool isPaused = false;

		void Update(){
			if (Input.GetButtonDown("Pause")){
				if(!isPaused){ //For Pausing
					print("Paused!");
					Time.timeScale = 0.0f;
					isPaused = true;
				}else{ //For Unpausing
					print("Unpaused!");
					Time.timeScale = 1.0f;
					isPaused = false;
				}
			}
		}

		void OnGUI(){
			
			if(isPaused){
				GUI.DrawTexture (new Rect ((Screen.width/2)-(Screen.width/4), (Screen.height/2)-(Screen.width/4), Screen.width/2, Screen.height/2), test);
			}
		}

	}