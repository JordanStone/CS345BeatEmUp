using UnityEngine;
using System.Collections;

public class hBar : MonoBehaviour {
	
	public int maxHealth = 100;
	public int curHealth = 100;
	
	public Texture2D bgImage; 
	public Texture2D fgImage; 

	public Texture2D overlayImg;

	float healthBarLength;
	
	// Use this for initialization
	void Start () {  
		healthBarLength = Screen.width /2;    
	}
	
	// Update is called once per frame
	void Update () {
		curHealth = this.GetComponent<Health> ().getHealth ();
		AddjustCurrentHealth(0);
	}
	
	void OnGUI () {

		GUI.DrawTexture (new Rect (-35,3,(Screen.width / 2) + 50,50), overlayImg);

		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,5, healthBarLength,50));
		
		// Draw the background image
		GUI.DrawTexture (new Rect (0,5, healthBarLength,50), bgImage);
		
		
		GUI.EndGroup ();
	}
	
	public void AddjustCurrentHealth(int adj){
		
		curHealth += adj;
		
		if(curHealth <0)
			curHealth = 0;
		
		if(curHealth > maxHealth)
			curHealth = maxHealth;
		
		if(maxHealth <1)
			maxHealth = 1;
		
		healthBarLength =(Screen.width /2) * (curHealth / (float)maxHealth);
	}
}
