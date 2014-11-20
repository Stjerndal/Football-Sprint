using UnityEngine;
using System.Collections;

public class CharSelectBtn : MonoBehaviour {
	
	public MainSceneController mainSceneController;
	public GameObject panel;
	public GameObject curChar;
	public GameObject achTextGameObject;
	public GUIText achText;
	public Texture2D btnUnlocked;
	public Texture2D btnLocked;
	public int charNr;

	bool unlocked = false;

	GUIAudio guiAudio;
	AchievementHandler achHandler;
	
	void Start () {
		guiAudio = GameObject.FindObjectOfType<GUIAudio>();
		achHandler = GameObject.Find ("AchievementController").GetComponent<AchievementHandler>();
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

	public void setEnabled(bool enabled) {
		if(enabled) {
			guiTexture.texture = btnUnlocked;
			unlocked = true;
		}
		else {
			guiTexture.texture = btnLocked;
			unlocked = false;
		}
	}

	void handlePress () {
		guiAudio.ButtonClick();
		if(unlocked) {
			mainSceneController.changeChar(charNr);
			curChar.SetActive(true);
			achTextGameObject.SetActive(false);
			panel.SetActive(false);
		} else {
			achText.text = achHandler.getAchTXT(charNr);
			achTextGameObject.SetActive(true);
		}
	}


}
