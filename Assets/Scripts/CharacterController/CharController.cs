using UnityEngine;
using System.Collections;

/*
 * 2D Character Controller for Player. Will likely eventually become a subclass of a Controller class that will also include enemies with similar behavior.
 */

public class CharController : MonoBehaviour{

	public AudioClip animsound1, animsound2, animsound3, animsound4;

	public float maxSpeed = 5; //Max speed value allowed
	public int defaultDamage = 10;
	protected int damage = 10;
	public Animator anim; //Will be implemented once we have animations
	
	public bool right = true; //What Direction Is Player Facing

	public Transform groundCheck; //Transform to Check for Ground
	public LayerMask groundType; //Define What Is Ground
	bool grounded = false; //Is player on ground
	float groundRadius = 0.2f; //Groundcheck radius

	bool jump = false; //Is player jumping
	public float jumpForce = 300f; //Max amount of jump force given

	bool roll = false; //Is player rolling
	bool rolling = false;
	public float rollForce = 50f; //Roll force given


	bool attackCool = false;
	bool comboCool = false;
	public float attackWait = 0.5f;
	protected float punchWait;
	public float comboTime = 1.0f;
	protected float cTimer = 0f;
	public float cEnd = 1.0f;
	public float timerSpeed = 0.2f;
	public GameObject hitbox;
	public Vector3 spawnPos;
	public Quaternion spawnRot;
	protected bool punchCool=false;
	protected bool tired = false;
	protected bool firstPunch = true;
	public float rollD = 5f;
	protected bool onlyOneExplozion = false;

	int punch = 0; //Is player punching. Int used to allow easy checking of punch states (combos, etc)
	//0 = Idle/Not Punching
	//1 = Default Punch
	//2 = Second Punch
	//3 = Third Punch / Finisher

	//4 = Air Punch
	//Unsure if we need more than that, unless we're allowing air punch combos which is usually kind of odd

	void Start(){
		anim = gameObject.GetComponent<Animator>(); //Will be implemented once we have animations
		hitbox = GameObject.Find("PlayerHit");
		spawnPos = this.transform.position;
		spawnRot = this.transform.rotation;
		punchWait = attackWait * 0.9f;
	}

	void Update(){
		//Debug.Log("comboTimer = " + cTimer);
		//punchWait = attackWait * 0.03f;
		if(punch > 0)
		{
			comboTimerUpdate();
		}
		comboEnder();
		
		if(Input.GetButtonDown("Jump") && grounded){ //Jump
			initiatePunch(0);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
			jump = true;
		}

		if(Input.GetButtonDown("Fire1") && grounded){ //Roll
			initiatePunch(0);
			/*if (right){
				rigidbody2D.AddForce(new Vector2(rollForce, 0f));
				rigidbody2D.velocity = new Vector2(-rollForce * maxSpeed,rigidbody2D.velocity.y + 1);
			}else{
				rigidbody2D.AddForce(new Vector2(-rollForce, 0f));
				rigidbody2D.velocity = new Vector2(rollForce * maxSpeed,rigidbody2D.velocity.y + 1);
			}*/
			roll = true;
		}

		if(rolling)
		{
			if(right)
			{
				this.transform.position += new Vector3(rollD * Time.deltaTime, 0f, 0f);
			}
			else
			{
				this.transform.position -= new Vector3(rollD * Time.deltaTime, 0f, 0f);
			}
			
		}

		if(Input.GetButtonDown("Fire2") && !roll){//Punch
			//comboEnder();	 
			//comboTimerUpdate();

			//StartCoroutine(comboEnder());
			/*if(firstPunch)
			{
				punch = punch;
				firstPunch = false;
			}*/

			if(!attackCool)
			{
			punch = punch;
			this.gameObject.tag = "PlayerAttack";

			switch(punch){
				case 0: //First time pressed
					if(grounded){ //Ground Contextual Attack Types
						//punch = 1;
						damage = defaultDamage;
						initiatePunch(1);
						comboTimerReset();
						//anim.SetInteger("punch", punch);
						//punch=0;
						//Apply Attack Damage Here. Probably using a method for this.
					}else{
						punch = 4;
						//Apply Attack Damage Here. Probably using a method for this.
					}
					break;

				case 1: //Second time pressed
					//punch = 2;
					damage = damage + damage/2;
					initiatePunch(2);
					comboTimerReset();
					//Apply Attack Damage Here. Probably using a method for this.
					break;

				case 2: //Third Time Pressed
					//punch = 3;
					damage = damage * 2;
					initiatePunch(3);
					comboTimerReset();
					//Apply Attack Damage Here. Probably using a method for this.
					break;
			}
		}
		else if(attackCool)
		{
			punch++;
		}
			

			
		}
			
	}

	void FixedUpdate(){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundType); //Are we on ground
		anim.SetBool("ground",grounded); //Let the Animator Know
		anim.SetFloat("vSpeed",GetComponent<Rigidbody2D>().velocity.y); //How fast are we going vertically
		float move;
		
		if(!attackCool && !rolling)
		{
			move = Input.GetAxis ("Horizontal"); //Get horizontal input

		}
		else
		{
			move = 0f;

		}
		

		anim.SetFloat("xSpeed",Mathf.Abs(move)); //How fast are we going horizontally


		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y); //Take input and move object

		//Orientation
		if (move > 0 && !right){
			Flip();
		}else if (move < 0 && right){
			Flip();
		}

		//Jump Animation
		if(jump){
			anim.SetTrigger("jump");
			GetComponent<AudioSource>().PlayOneShot (animsound4);
			jump = false;
		}

		//Roll Animation
		if(roll){
			anim.SetTrigger("roll");
			StartCoroutine(rollTime());
			StartCoroutine(rollInvince());
			roll = false;
		}

		//Punch Animation
		if(punch > 0 && !attackCool){ //We have punch
			switch(punch){
				case 1:
				 //anim.SetInteger("punch", 1);
				 StartCoroutine(attackCooldown(attackWait, punch));
				 //StartCoroutine(punchCooldown(punchWait));
				 //audio.PlayOneShot (animsound1);
					//trigger for regular punch animation
					break;
				case 2:
					StartCoroutine(attackCooldown(attackWait, punch));
					//StartCoroutine(punchCooldown(punchWait));
					//audio.PlayOneShot (animsound2);
					//trigger for second punch animation
					break;
				case 3:
					StartCoroutine(attackCooldown(attackWait, punch));
					//StartCoroutine(punchCooldown(punchWait));
					//audio.PlayOneShot (animsound3);
					//trigger for third punch animation
					//punch = 0;
					break;
				case 4:
					//trigger for air punch animation
					//punch = 0;
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

	public int getDamage()
	{
		return damage;
	}

	IEnumerator attackCooldown(float waitTime, int p)
	{
		attackCool = true;
		//punchCool = true;
		yield return new WaitForSeconds(waitTime);
		onlyOneExplozion = false;
		//punchCool = false;
		//yield return new WaitForSeconds(waitTime * 0.5f);
		if(punch == p && attackCool)
		{
			initiatePunch(0);
			attackCool = false;
		}
		else if(p < punch && p < 3 && attackCool)
		{
			//attackCool = false;
			initiatePunch(p + 1);
			comboTimerReset();
			StartCoroutine(attackCooldown(waitTime, p + 1));
		}
		else
		{

			initiatePunch(0);
			attackCool = false;
		}
		attackCool = false;

	}


	IEnumerator punchCooldown(float coolTime)
	{
		punchCool = true;
		yield return new WaitForSeconds(coolTime);
		punchCool = false;

	}

	void initiatePunch(int i)
	{
		punch = i;
		anim.SetInteger("punch", punch);
		if (i == 0) {
			this.gameObject.tag = "Player";
			damage = defaultDamage;
			StartCoroutine(staminaCool());
		} else if (i == 1) {
			GetComponent<AudioSource>().PlayOneShot (animsound1);
		} else if (i == 2) {
			damage = defaultDamage + damage/2;
			GetComponent<AudioSource>().PlayOneShot (animsound2);
		} else if (i == 3) {
			if(!tired)
			{
				GameObject rangeDamage = (GameObject) Instantiate (Resources.Load("HitExplozion"));
				rangeDamage.transform.position = this.gameObject.transform.position;
				StartCoroutine(staminaCool());
			}
			damage = defaultDamage * 2;
			GetComponent<AudioSource>().PlayOneShot (animsound3);
		}
	}

	void comboEnder()
	{
		if(cTimer >= cEnd)
		{
			initiatePunch(0);
		}

	}

	IEnumerator rollTime()
	{
		rolling = true;
		yield return new WaitForSeconds(0.75f);
		rolling = false;
	}

	IEnumerator rollInvince()
	{
		hitbox.layer = 14;
		this.gameObject.layer = 14;
		yield return new WaitForSeconds(0.43f);
		hitbox.layer = 8;
		this.gameObject.layer = 8;
	}

	public bool getFace()
	{
		return right;
	}

	public Vector3 getSpawnPos()
	{
		return spawnPos;
	}

	public Quaternion getSpawnRot()
	{
		return spawnRot;
	}

	void comboTimerUpdate()
	{
		cTimer += timerSpeed * Time.deltaTime;

	}
	void comboTimerReset()
	{
		cTimer = 0f;
	}

	IEnumerator staminaCool()
	{
		tired = true;
		yield return new WaitForSeconds(5f);
		tired = false;
	}


}
