using UnityEngine;
using System.Collections;

/*
 * 2D Character Controller for Player. Will likely eventually become a subclass of a Controller class that will also include enemies with similar behavior.
 */

public class CharController : MonoBehaviour{

	public float maxSpeed = 5; //Max speed value allowed
	public Animator anim; //Will be implemented once we have animations
	
	bool right = true; //What Direction Is Player Facing

	public Transform groundCheck; //Transform to Check for Ground
	public LayerMask groundType; //Define What Is Ground
	bool grounded = false; //Is player on ground
	float groundRadius = 0.2f; //Groundcheck radius

	bool jump = false; //Is player jumping
	public float jumpForce = 300f; //Max amount of jump force given

	bool roll = false; //Is player rolling
	public float rollForce = 5000f; //Roll force given

	int punch = 0; //Is player punching. Int used to allow easy checking of punch states (combos, etc)
	//0 = Idle/Not Punching
	//1 = Default Punch
	//2 = Second Punch
	//3 = Third Punch / Finisher

	//4 = Air Punch
	//Unsure if we need more than that, unless we're allowing air punch combos which is usually kind of odd

	void Start(){
		anim = gameObject.GetComponent<Animator>(); //Will be implemented once we have animations
	}

	void Update(){
		
		if(Input.GetButtonDown("Jump") && grounded){ //Jump
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = true;
		}

		if(Input.GetButtonDown("Fire1") && grounded){ //Roll
			if (right){
				rigidbody2D.AddForce(new Vector2(rollForce, 0f));
			}else{
				rigidbody2D.AddForce(new Vector2(-rollForce, 0f));
			}
			roll = true;
		}

		if(Input.GetButtonDown("Fire2") && !roll){ //Punch

			switch(punch){
				case 0: //First time pressed
					if(grounded){ //Ground Contextual Attack Types
						punch = 1;
						//Apply Attack Damage Here. Probably using a method for this.
					}else{
						punch = 4;
						//Apply Attack Damage Here. Probably using a method for this.
					}
					break;

				case 1: //Second time pressed
					punch = 2;
					//Apply Attack Damage Here. Probably using a method for this.
					break;

				case 2: //Third Time Pressed
					punch = 3;
					//Apply Attack Damage Here. Probably using a method for this.
					break;
			}
			

			
		}
			
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundType); //Are we on ground
		anim.SetBool("ground",grounded); //Let the Animator Know
		anim.SetFloat("vSpeed",rigidbody2D.velocity.y); //How fast are we going vertically
		
		float move = Input.GetAxis ("Horizontal"); //Get horizontal input

		anim.SetFloat("xSpeed",Mathf.Abs(move)); //How fast are we going horizontally

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y); //Take input and move object

		//Orientation
		if (move > 0 && !right){
			Flip();
		}else if (move < 0 && right){
			Flip();
		}

		//Jump Animation
		if(jump){
			anim.SetTrigger("jump");

			jump = false;
		}

		//Roll Animation
		if(roll){
			anim.SetTrigger("roll");

			roll = false;
		}

		//Punch Animation
		if(punch > 0){ //We have punch
			switch(punch){
				case 1:
					//trigger for regular punch animation
					break;
				case 2:
					//trigger for second punch animation
					break;
				case 3:
					//trigger for third punch animation
					punch = 0;
					break;
				case 4:
					//trigger for air punch animation
					punch = 0;
					break;
			}
		}

	}

/*
 * Flip switches the facing direction of the character. 
 */
	void Flip(){
		right = !right;
		Vector3 scale = transform.localScale;
		scale.x = scale.x * -1;
		transform.localScale = scale;
	}

}
