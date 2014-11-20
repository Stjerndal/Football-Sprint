using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float playerScore = 0;
	public GUIText scoreTextField;
	
	// Update is called once per frame
	void Update () {
		playerScore += Time.deltaTime;
	}

	public void IncreaseScore(int amount) {
		playerScore += amount;
	}

	void OnGUI() {
		scoreTextField.text = "Score:" + (int)(playerScore * 100);
		//scoreTextField.text = "Score: hehuehue";
		//GUI.Label(new Rect(10, 10, 100, 30), "Score: " + (int)(playerScore * 100));
	}

	public void OnDisable () {
		//TODO Plain text file, better to keep a packet with the score in it
		//persist that, using a DontDestroyOnLoad.
		PlayerPrefs.SetInt("Score", (int)(playerScore*100));
	}
}
