using UnityEngine;
using System.Collections;

public class BlobMovement : MonoBehaviour {

	public float walkRadius = 6f;			// the maximum radius a blob may travel
	public float epsilon = 1f;				// error value to measure distance between current and target position
	public float talkingRadius = 3f;		// radius to be able to interact with blob
	public MeshRenderer[] bodyParts;		// tthings to change the colors of 

	Transform playerTransform;			// if blob wants to follow player or something
	bool isMoving = false;				// is the blob moving? else stationary
	Vector3 randomDir;					// a random direction to walk in
	Vector3 targetPos;					// the final random target position
	NavMeshAgent nav;

	void Awake () {
		// playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();

		// make a random color
		Color col = new Color(Random.value, Random.value, Random.value);
		for (int i = 0; i < bodyParts.Length; i++) {
			bodyParts[i].material.color = col;
		}
	}

	void Update () {
		// nav.SetDestination(player.position); 	// you are so popular *~*~*~
		ChooseAction();
	}

	// Debugging, show the radius where the blob can walk
	void OnDrawGizmos() {
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, walkRadius);
	}

	// should i stay or should i go, unh unh unh
	void ChooseAction () {
		// if not already en route to a destination, decide whether to move or stay
		// else check if we have reached target position, and stay there
		if (!isMoving) {
			if (Random.value < 0.2f * Time.deltaTime) {
				isMoving = true;
				nav.enabled = true;
				targetPos = ChooseRandomPos();
				nav.SetDestination(targetPos);
			}
		} else {
			if (Mathf.Abs(transform.position.x - targetPos.x) < epsilon &&
			    Mathf.Abs(transform.position.z - targetPos.z) < epsilon) {
				isMoving = false;
				nav.enabled = false;
			}
		}
	}

	// returns a random position on the nav mesh
	Vector3 ChooseRandomPos () {
		// set a random direction
		float minDistance = walkRadius / 8;
		Vector2 randomCircle = Random.insideUnitCircle * walkRadius;
		randomDir = new Vector3 (randomCircle.x + minDistance, 0f, randomCircle.y + minDistance);

		// check if travelling to the point is still in the navmesh
		randomDir += transform.position;
		NavMeshHit hit;
		NavMesh.SamplePosition(randomDir, out hit, walkRadius, 1);
		return hit.position;
	}
}







