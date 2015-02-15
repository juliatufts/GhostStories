using UnityEngine;
using System.Collections;

public class BlobGenerator : MonoBehaviour {

	public GameObject blob;
	public Transform blobs;
	public int numBlobs = 1;
	public GameObject floor;  // the floor is needed to spawn blobs in range
	
	float u = 5f;			  // unity unit?
	float buffer = 0.5f;	  // buffer to prevent spawning in walls
	float xMax;				  // max x position where the blob will appear, in unity units
	float zMax;				  // max z position where the blob will appear, in unity units
	Vector3 pos;	  	      // the position of the blob will be spawned
	Quaternion quat; 		  // the rotation of the blob will be spawned
	

	void Start () {
		xMax = floor.transform.localScale.x;
		zMax = floor.transform.localScale.z;
		Spawn (numBlobs);
	}


	void Spawn (int numBlobs) {

		for (int i = 0; i < numBlobs; i++) {
			// random position
			pos = new Vector3 (Random.Range(-xMax * u + buffer, xMax * u - buffer),
			         		   0f,
			                   Random.Range(-zMax * u + buffer, zMax * u - buffer));

			// random rotation
			quat = Quaternion.Euler(0, Random.Range(0, 360), 0);

			// random material will go here

			// spawn that blob
			GameObject newBlob = Instantiate (blob, pos, quat) as GameObject;
			newBlob.transform.parent = blobs;
		}
	}
}
