using UnityEngine;
using System.Collections;

/*
 * 2D Character Controller for Player. Will likely eventually become a subclass of a Controller class that will also include enemies with similar behavior.
 */

public class EnemyController : MonoBehaviour{

	public AudioClip animsound1;
	public float maxSpeed = 3; //Max speed value allowed
//	public Animator anim; //Will be implemented once we have animations

	Transform target;
	Transform enemyTransform;
	public float speed = 3f;
	public float rotationSpeed=3f;
	public Animator anim;
	public int damage = 1;
	
	bool right = true; //What Direction Is Player Facing
	
	public Transform groundCheck; //Transform to Check for Ground
	public LayerMask groundType; //Define What Is Ground
	bool grounded = false; //Is player on ground
	float groundRadius = 0.2f; //Groundcheck radius
	public float attackDistance = 1.0f;
	float actualDistance;
	int attackPlayer;
	float dodgeForce = 1000;
	int randomChoice;
	bool attackCool = false;
	public float waitTime = 0.5f;
	bool walk = false;
	bool attacking = false;
	
	bool attack = false;

	
	void Start(){
		anim = gameObject.GetComponent<Animator>(); //Will be implemented once we have animations
		enemyTransform = this.GetComponent<Transform>();
		target = GameObject.FindWithTag ("Player").transform;
	}
	
	void Update(){

		actualDistance = target.position.x - enemyTransform.position.x;
		//Debug.Log("actualDistance" + actualDistance);
		
		if(actualDistance <= attackDistance && !attacking)
		{
			walk = false;
			randomChoice = Random.Range(1, 2);


			if(randomChoice >= 1)
			{
				//Debug.Log("ATTACK!");
				Attack();

			}
			else
			{
				//Debug.Log("Move!");
				MoveBack();
			}

		}
		else{
			walk = true;
			anim.SetTrigger("walking");
				if(target.position.x > enemyTransform.position.x)
		{
		enemyTransform.position += enemyTransform.right * speed * Time.deltaTime;
		}
		else{
			enemyTransform.position -= enemyTransform.right * speed * Time.deltaTime;
		}

		}
		
		//rotate to look at the player
		
//		transform.rotation = Quaternion.LookRotation(targetDirection); // Converts target direction vector to Quaternion
//		transform.eulerAngles = new Vector3(0, 0, 0);
		
		//move towards the player

	
		

		
	}
	
	void FixedUpdate(){
		
		Vector2 targetHeading = target.position - transform.position;
		Vector2 targetDirection = targetHeading.normalized;

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundType); //Are we on ground
//		anim.SetBool("ground",grounded); //Let the Animator Know
//		anim.SetFloat("vSpeed",rigidbody2D.velocity.y); //How fast are we going vertically
		
		float move = Input.GetAxis ("Horizontal"); //Get horizontal input
		
//		anim.SetFloat("xSpeed",Mathf.Abs(move)); //How fast are we going horizontally
		
		rigidbody2D.velocity = new Vector2(speed * targetDirection.x, rigidbody2D.velocity.y); //Update this to move towards player
		
		//Orientation
		if (targetHeading.x >= 0 && !right){ //Player to the left
			Flip();
		}else if (targetHeading.x < 0 && right){ //Player to the right
			Flip();
		}

		if (attack) {
//			anim.SetTrigger ("attack");

			attack = false;
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

	void Attack()
	{
		anim.SetInteger ("Attack", 1);
		audio.PlayOneShot (animsound1);


		this.gameObject.tag = "EnemyAttack";
		StartCoroutine(attackCooldown(waitTime));


	}

	IEnumerator attackCooldown(float waiting)
	{
		attackCool = true;
		attacking = true;
		yield return new WaitForSeconds(waiting);
		anim.SetInteger("Attack", 0);
		this.gameObject.tag = "Enemy";
		attackCool = false;
		attacking = false;
	}

	void MoveBack()
	{
		Vector2 targetHeading = target.position - transform.position;
		Vector2 targetDirection = targetHeading.normalized;

		if (targetHeading.x >= 0 && !right){ //Player to the left
			this.gameObject.rigidbody2D.AddForce(new Vector2(-dodgeForce, 0f));
		}else if (targetHeading.x < 0 && right){ //Player to the right
			this.gameObject.rigidbody2D.AddForce(new Vector2(dodgeForce, 0f));
		}

	}
	public int getDamage()
	{
		return damage;
	}
	
}
