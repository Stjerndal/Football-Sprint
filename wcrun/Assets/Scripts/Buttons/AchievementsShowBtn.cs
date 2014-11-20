using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class AchievementsShowBtn : MonoBehaviour {
	
	GUIAudio guiAudio;
	
	void Start () {
		PlayGamesPlatform.Activate();
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
		if(!Social.Active.localUser.authenticated) {
			Social.localUser.Authenticate((bool success) => {
				// handle success or failure
				if(success) {
					Social.ShowAchievementsUI();
				}
			});
        } else {
            Social.ShowAchievementsUI();
        }
    }
}
