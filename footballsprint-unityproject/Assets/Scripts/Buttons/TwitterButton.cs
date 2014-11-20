using UnityEngine;
using System.Collections;

public class TwitterButton : MonoBehaviour {

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en"; 
	public GameScreenController gameScreenController;
	public CharIDTranslator cTranslator;
	
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
		string twitterText = "I just scored " + (int)gameScreenController.playerScore
							+ " points for #" + cTranslator.translate(gameScreenController.curChar)
							+ " in #WorldCupSprint! Can you beat me? ANDROID: "
				+ "https://play.google.com/store/apps/details?id=se.stjerndal.wcsprint" +
							" #WorldCup";

		Application.OpenURL(TWITTER_ADDRESS +
		                    "?text=" + WWW.EscapeURL(twitterText) +
		                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}
	
}
