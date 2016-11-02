using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {
	
	public bool moving;
	public float  y;
	Animator anim;
	public bool up;											//true if up, false if down
	public float speed;

	void Start () {
		anim = GetComponent<Animator> ();
		moving = false;
	}

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.K)) {
			anim.Play ("CloseDoors");
			GameObject Player = GameObject.Find("Player");
			PlayerController plScript = Player.GetComponent<PlayerController>();
			y = plScript.CurrIng.floor * 7.5f;
			moving = true;
			if (transform.position.y < y)
				up = true;
			if (transform.position.y > y)
				up = false;

		}

		if (moving && transform.position.y < y && up)
			transform.Translate (0, speed * Time.deltaTime, 0);

		if (moving && transform.position.y > y && !up)
			transform.Translate (0, -speed * Time.deltaTime, 0);

		if (moving && transform.position.y > y && up) {
			moving = false;
			anim.Play ("OpenDoors");
		}

		if (moving && transform.position.y < y && !up) {
			moving = false;
			anim.Play ("OpenDoors");
		}
	}
			
}
	





	