using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	GameObject player;
	PlayerTalk playerTalk;
	BlobTalk blobTalk;
	Text playerText;
	Text blobText;

	// Use this for initialization
	void Awake () {
		// assign playerTalk and blobTalk scripts
		player = GameObject.FindGameObjectWithTag("Player");
		playerTalk = player.GetComponent<PlayerTalk>();

		// find text components and assign them to variables
		Component[] textComponents;
		textComponents = GetComponentsInChildren<Text>();
		foreach (Text t in textComponents) {
			if (t.name == "PlayerText") {
				playerText = t;
			} else {
				blobText = t;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTalk.engaged) {
			playerText.text = "hai";
			blobText.text = "acknowledge your existence";
		}
	}
}
