using UnityEngine;
using System.Collections;

public class BlobTalk : MonoBehaviour {

	public float talkingRadius = 3f;
	public bool engaged;						// engaged in conversation?
	public PlayerTalk playerTalk;
	public PlayerMovement playerMovement;

	GameObject player;
	BlobMovement blobMovement;
	
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		playerTalk = player.GetComponent<PlayerTalk>();
		playerMovement = player.GetComponent<PlayerMovement>();

		blobMovement = this.GetComponent<BlobMovement>();
		engaged = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// if the player clicks on a blob and is within talking distance, enter conversation mode
	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, player.transform.position) < talkingRadius && !engaged) {
			Debug.Log ("talk to me");
			engaged = true;
			playerTalk.engaged = true;

			blobMovement.enabled = false;
			playerMovement.enabled = false;
		}
	}
}
