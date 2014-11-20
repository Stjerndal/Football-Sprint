using UnityEngine;
using System.Collections;

public class SceneChangeButton : MonoBehaviour {

	public int SceneNr;

	GUIAudio guiAudio;
	
	void Start () {
		guiAudio = GameObject.FindObjectOfType<GUIAudio>();
	}

	//NOT WORKING FOR SOME REASON:
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
		PlayerPrefs.SetInt("fromGame", 1);
		Application.LoadLevel(SceneNr);
	}

}
