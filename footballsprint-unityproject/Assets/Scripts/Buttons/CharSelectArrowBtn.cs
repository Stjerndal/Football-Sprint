using UnityEngine;
using System.Collections;

public class CharSelectArrowBtn : MonoBehaviour {

	public GameObject thisPage;
	public GameObject nextPage;
	public GameObject achTextGameObject;
	
	GUIAudio guiAudio;
	
	void Start () {
		guiAudio = GameObject.FindObjectOfType<GUIAudio>();
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
	
	void handlePress () {
		guiAudio.ButtonClick();
		thisPage.SetActive(false);
		achTextGameObject.SetActive(false);
		nextPage.SetActive(true);
	}
}