using UnityEngine;
using System.Collections;

public class RestartGameBtn : MonoBehaviour {

	public GameScreenController gameScreenController;

	GUIAudio guiAudio;
	PlayerAudio playerAudio;
	
	void Start () {
		guiAudio = GameObject.FindObjectOfType<GUIAudio>();
		playerAudio = GameObject.FindObjectOfType<PlayerAudio>();
	}

	#if !(UNITY_ANDROID || UNITY_IPHONE) || UNITY_EDITOR
	void OnMouseDown() {
		handlePress();
	}
	#endif

	#if UNITY_ANDROID || UNITY_IPHONE
	void Update() {
		if(Input.touchCount > 0) {
			foreach(Touch touch in Input.touches) {
				if(touch.phase == TouchPhase.Began && guiTexture.HitTest(touch.position)) {
					handlePress();
				}
			}
		}
	}
	#endif

	void handlePress() {
		guiAudio.ButtonClick();
		playerAudio.StopAll();
		gameScreenController.RestartGame();
	}
	
}
