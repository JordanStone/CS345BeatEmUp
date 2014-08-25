using UnityEngine;
using System.Collections;

/* This class is for any required global scripts that should be accessable from any other script / object.
Functions should be static such that other scripts can call them via "GlobalConditions.FUNCTIONNAME()"

Script still needs to be attached to an object to function. I prefer the MainCamera, but it can be any object 
that is never destroyed in the scene / level. -Jordan
*/

public class GlobalConditions : MonoBehaviour {

	public static void onDeath(bool isPlayer){
		if(isPlayer){ //If player died, go to game over screen.
			goToGameOver();
		}
	}

/*Called when scene needs to change to Game Over. 
Seperate method as there may other functionality we want to set when the scene changes.*/
	static void goToGameOver(){ 
		Application.LoadLevel("GameOver");	
	}

/*Called when scene needs to change to Victory scene (not implemented yet). 
Seperate method as there may other functions we want to set when the scene changes.*/
	static void goToVictory(){
//		Application.LoadLevel("Victory"); 
	}

}