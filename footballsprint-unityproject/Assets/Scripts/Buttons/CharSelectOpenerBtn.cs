using UnityEngine;
using System.Collections;

public class CharSelectOpenerBtn : MonoBehaviour {
	
	public GameObject target;
	public GameObject page1;
	public GameObject page2;
	public GameObject page3;
	public GameObject page4;
	
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
		page2.SetActive(false);
		page3.SetActive(false);
		page4.SetActive(false);
		page1.SetActive(true);
		target.SetActive(true);
		gameObject.SetActive(false);
	}
}
