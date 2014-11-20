using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class MainSceneController : MonoBehaviour {

//	int bestScore = 0;
	public GUIText scoreTextField;
	public BannerAd bannerAd;
	public InterstitialAdScript interstitial;
	public FlagSelector flagSelector;
	public GUITexture curCharTexture;
	AchievementHandler achHandler;
	public CharSelectBtn[] charSelectBtns;
	MusicAudio musicController;

	public int curChar;
	int totalBalls;

	// Use this for initialization
	void Start () {
//		achHandler.RESET_PLAYER_PREFS();

		#if UNITY_ANDROID
		// Pass in the ID & Signature for "Swing Doge"
//		Advertisement.Initialize ("80958d9203ae73f8", "dce2ad008b8d46d6");
		// Pass in the ID & Signature for "World Cup Sprint"
//		Advertisement.Initialize ("37fcbfd2e0aa0011", "1a8cc0d1de042c9c");
		Advertisement.Initialize ("80958d9203ae73f8", "dce2ad008b8d46d6");
		#endif
		achHandler = GameObject.FindObjectOfType<AchievementHandler>();

//TODO	bannerAd.Load();
		unlockButtons();



		if(PlayerPrefs.GetInt("fromGame", 0) == 0) {
			if(!Social.Active.localUser.authenticated) {
				Social.localUser.Authenticate((bool success) => {});
            }
			int numLaunches = PlayerPrefs.GetInt("numLaunches", 0);
			numLaunches++;
			if(numLaunches <= 1) {
				achHandler.unlockFirst();
			}else if(numLaunches > 6) {
//TODO			interstitial.Load();
			}
			PlayerPrefs.SetInt("numLaunches", numLaunches);
		} else {
			PlayerPrefs.SetInt("fromGame", 0);
		}




		curChar = PlayerPrefs.GetInt("curChar");
		curCharTexture.texture = flagSelector.getFlag(curChar);
		musicController = GameObject.FindObjectOfType<MusicAudio>();
//		achHandler = GameObject.FindObjectOfType<AchievementHandler>();

	}

	void unlockButtons () {
		for(int i = 0; i < charSelectBtns.Length; i++) {
			charSelectBtns[i].setEnabled(achHandler.checkAchievement(i));
		}
	}

	void Update() {
		//Ensure we have an available interstitial to show
		if (Advertisement.availableCount > 0)
		{
			//ShowOptions has two values: resultCallback, a callback which returns one of Closed, Failed or Clicked
			//  and pause, which tells us whether or not to pause the app while showing an interstitial.
			//  pause is true by default
			ShowOptions showOptions = new ShowOptions()
			{
				resultCallback = OnInterstitialResult
			};
			
			//When calling show, if any errors were received by failed downloads, wrong urls, etc.
			//It will iterate through those errors until it finds an interstitial to show.
			Advertisement.Show(showOptions);
		}
	}

	private void OnInterstitialResult(ShowResult showResult)
	{
		Debug.Log("Interstitial Result: " + showResult);
	}
	

	public void changeChar(int newChar) {
		curChar = newChar;
		PlayerPrefs.SetInt("curChar", curChar);
		curCharTexture.texture = flagSelector.getFlag(curChar);
	}

	public void SetMusicEnabled(bool enabled) {
		musicController.SetMusicPlaying(enabled);
		PlayerPrefs.SetInt("musicEnabled", (enabled ? 1 : 0));
	}

	void OnDisable() {
		bannerAd.kill();
		if(interstitial)
			interstitial.kill();
		achHandler.storeAchievements();
	}

}
