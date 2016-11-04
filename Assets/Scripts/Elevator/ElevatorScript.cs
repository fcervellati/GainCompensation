using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour {
	
	public bool moving;
	public float  y;
	Animator anim;
	public float speed;
	public GameObject Player;
	public PlayerController plScript;
	public Vector3 target;

	void Start () {
		anim = GetComponent<Animator> ();
		moving = false;
		plScript = Player.GetComponent<PlayerController>();

	}

	void Update () {
		
		if (Input.GetKeyDown (KeyCode.F) && Player.transform.parent != null && !moving) {					//move with F only if the player is in the elevator
			anim.Play ("CloseDoors");
			target = new Vector3 (0, plScript.CurrIng.floor * 7.5f, -8.25f);
			moving = true;
		}

		if (moving) {
			Vector3 dir = target - this.transform.position;
			float distFrame = speed * Time.deltaTime;
			if (dir.magnitude < distFrame) {												// move exactly to destination position
				this.transform.position = target;
				moving = false;
				anim.Play ("OpenDoors");
			} else {
					this.transform.Translate (dir.normalized * distFrame, Space.World);
				}
		}

	}
			
}
	





	