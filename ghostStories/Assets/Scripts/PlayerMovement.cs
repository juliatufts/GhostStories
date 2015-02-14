using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;
	
	Vector3 movement;
	Animator anim;				// in case i want different animations for walking and stuff later
	int floorMask;
	float camRayLength = 100f;

	// set up references
	void Awake () {
		floorMask = LayerMask.GetMask("Floor");		   // need the floor to do a raycast
		anim = GetComponent<Animator>();
	}

	// movement
	void FixedUpdate () {
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		Move (h, v);
		Turn ();
	}

	void Move (float h, float v) {
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;	// normalize, scale and calculate how much to move per second
		transform.Translate(movement);
	}

	void Turn () {
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			transform.rotation = newRotation;
		}
	}
}



