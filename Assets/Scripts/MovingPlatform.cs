using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	private float useSpeed;
	public float directionSpeed = 9.0f;
	float Yorigin;
	public float distance = 10.0f;

	public float delay = 0.0f;
	bool check = false;

	void Start(){
		while(true){
			StartCoroutine(Delayer());
			break;
		}
		
		Yorigin = transform.position.y;
		useSpeed = -directionSpeed;
	}

	void Update(){
		if(check){
			if(Yorigin - transform.position.y > 0){
			useSpeed = directionSpeed;
			}else if(Yorigin - transform.position.y < -distance){
				useSpeed = -directionSpeed;
			}
			transform.Translate(0,useSpeed*Time.deltaTime,0);
		}
		
	}

	IEnumerator Delayer(){
		yield return new WaitForSeconds(delay);
		check = true;
	}
}