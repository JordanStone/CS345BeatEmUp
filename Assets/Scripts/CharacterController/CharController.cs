using UnityEngine;
using System.Collections;

/*
 * 2D Character Controller for Player. Will likely eventually become a subclass of a Controller class that will also include enemies with similar behavior.
 */

public class CharController : MonoBehaviour{

	public float maxSpeed = 5; //Max speed value allowed
	public Animator anim; //Will be implemented once we have animations
	
	bool right = true;

	public Transform groundCheck;
	public LayerMask groundType;
	bool grounded = false;
	float groundRadius = 0.2f;

	bool jump = false;
	public float jumpForce = 300f; //Max amount of jump force given

	bool roll = false;
	public float rollForce = 600f;

	void Start(){
		anim = gameObject.GetComponent<Animator>(); //Will be implemented once we have animations
	}

	void Update(){
		
		if(Input.GetButtonDown("Jump") && grounded){ //Jump
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			jump = true;
		}

		if(Input.GetButtonDown("Fire1") && grounded){ //Roll
			rigidbody2D.AddForce(new Vector2(rollForce, 0f));
			roll = true;
		}

			
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundType); //Are we on ground
		anim.SetBool("ground",grounded);
		anim.SetFloat("vSpeed",rigidbody2D.velocity.y);
		
		float move = Input.GetAxis ("Horizontal"); //Get horizontal input

		anim.SetFloat("Speed",Mathf.Abs(move));

		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y); //Take input and move object

		if (move > 0 && !right){
			Flip();
		}else if (move < 0 && right){
			Flip();
		}

		if(jump){
			anim.SetTrigger("jump");

			jump = false;
		}

		if(roll){
			anim.SetTrigger("roll");

			roll = false;
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
