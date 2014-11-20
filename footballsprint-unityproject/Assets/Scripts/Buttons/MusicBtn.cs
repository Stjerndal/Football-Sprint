using UnityEngine;
using System.Collections;

public class MusicBtn : MonoBehaviour {

	public Texture2D btnEnabled;
	public Texture2D btnDisabled;
	public MainSceneController mainSceneController;

	bool musicEnabled;

	GUIAudio guiAudio;
	
	void Start () {
		guiAudio = GameObject.FindObjectOfType<GUIAudio>();
		musicEnabled = (PlayerPrefs.GetInt("musicEnabled", 1) == 1);
		if(musicEnabled)
			guiTexture.texture = btnEnabled;
		else
			guiTexture.texture = btnDisabled;
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
		musicEnabled = !musicEnabled;
		if(musicEnabled)
			guiTexture.texture = btnEnabled;
		else
			guiTexture.texture = btnDisabled;
		mainSceneController.SetMusicEnabled(musicEnabled);
	}

	
}
