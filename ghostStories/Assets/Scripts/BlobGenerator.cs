using UnityEngine;
using System.Collections;

public class BlobGenerator : MonoBehaviour {

	public GameObject blob;
	public Transform blobs;
	public int numBlobs = 1;
	public GameObject floor;  	// the floor is needed to spawn blobs in range
	public GameObject doorway;  // the doorway position is needed to spawn blobs there
	
	float u = 5f;			  // unity unit?
	float buffer = 0.5f;	  // buffer to prevent spawning in walls
	float xMax;				  // max x position where the blob will appear, in unity units
	float zMax;				  // max z position where the blob will appear, in unity units
	Vector3 pos;	  	      // the position of the blob will be spawned
	Quaternion quat; 		  // the rotation of the blob will be spawned
	

	IEnumerator Start () {
		// spawn at random points
		xMax = floor.transform.localScale.x;
		zMax = floor.transform.localScale.z;
		SpawnRandom (numBlobs);
		return null;


		// spawn at doorway in waves
		// yield return StartCoroutine(Spawn(2F));
	}

	IEnumerator Spawn(float waitTime) {
		yield return new WaitForSeconds(waitTime);
		SpawnAtDoorway(5);
	}
	
	void SpawnAtDoorway (int numBlobs) {
		pos = doorway.transform.position;
		Debug.Log("doorway:");
		Debug.Log(pos);
		for (int i = 0; i < numBlobs; i++) {
			// spawn that blob
			Debug.Log ("Actually making blob");
			GameObject newBlob = Instantiate (blob, pos, Quaternion.identity) as GameObject;
			newBlob.transform.parent = blobs;
		}
	}

	// spawn at random positions on the floor
	void SpawnRandom (int numBlobs) {

		for (int i = 0; i < numBlobs; i++) {
			// random position
			pos = new Vector3 (Random.Range(-xMax * u + buffer, xMax * u - buffer),
			         		   0f,
			                   Random.Range(-zMax * u + buffer, zMax * u - buffer));

			// random rotation
			quat = Quaternion.Euler(0, Random.Range(0, 360), 0);

			// spawn that blob
			GameObject newBlob = Instantiate (blob, pos, quat) as GameObject;

			newBlob.transform.parent = blobs;
		}
	}
}
