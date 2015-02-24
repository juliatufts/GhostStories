using UnityEngine;
using System.Collections;

public class PlayerTalk : MonoBehaviour {

	public bool engaged;

	string leftChoice;
	string rightChoice;
	
	void Awake () {
		engaged = false;
		leftChoice = "acknowledge acquaintance";
		rightChoice = "introduce yourself";
	}
	
	// Update is called once per frame
	void Update () {
		if (engaged) {
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {

			}
		}
	}
}
