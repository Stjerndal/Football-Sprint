using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class AchievementHandler : MonoBehaviour {
	#region ACH. IDs
	const string ID_ACH_0 = "CgkI95yh8ZUVEAIQAQ";
	const string ID_ACH_1 = "CgkI95yh8ZUVEAIQAg";
	const string ID_ACH_2 = "CgkI95yh8ZUVEAIQAw";
	const string ID_ACH_3 = "CgkI95yh8ZUVEAIQBA";
	const string ID_ACH_4 = "CgkI95yh8ZUVEAIQBQ";
	const string ID_ACH_5 = "CgkI95yh8ZUVEAIQCQ";
	const string ID_ACH_6 = "CgkI95yh8ZUVEAIQCg";
	const string ID_ACH_7 = "CgkI95yh8ZUVEAIQCw";
	const string ID_ACH_8 = "CgkI95yh8ZUVEAIQDA";
	const string ID_ACH_9 = "CgkI95yh8ZUVEAIQDQ";
	const string ID_ACH_10 = "CgkI95yh8ZUVEAIQDg";
	const string ID_ACH_11 = "CgkI95yh8ZUVEAIQDw";
	const string ID_ACH_12 = "CgkI95yh8ZUVEAIQEA";
	const string ID_ACH_13 = "CgkI95yh8ZUVEAIQEQ";
	const string ID_ACH_14 = "CgkI95yh8ZUVEAIQEg";
	const string ID_ACH_15 = "CgkI95yh8ZUVEAIQEw";
	const string ID_ACH_16 = "CgkI95yh8ZUVEAIQFA";
	const string ID_ACH_17 = "CgkI95yh8ZUVEAIQFQ";
	const string ID_ACH_18 = "CgkI95yh8ZUVEAIQFg";
	const string ID_ACH_19 = "CgkI95yh8ZUVEAIQFw";
	const string ID_ACH_20 = "CgkI95yh8ZUVEAIQGA";
	const string ID_ACH_21 = "CgkI95yh8ZUVEAIQGQ";
	const string ID_ACH_22 = "CgkI95yh8ZUVEAIQGg";
	const string ID_ACH_23 = "CgkI95yh8ZUVEAIQGw";
	const string ID_ACH_24 = "CgkI95yh8ZUVEAIQHA";
	const string ID_ACH_25 = "CgkI95yh8ZUVEAIQHQ";
	const string ID_ACH_26 = "CgkI95yh8ZUVEAIQHg";
	const string ID_ACH_27 = "CgkI95yh8ZUVEAIQHw";
	const string ID_ACH_28 = "CgkI95yh8ZUVEAIQIA";
	const string ID_ACH_29 = "CgkI95yh8ZUVEAIQIQ";
	const string ID_ACH_30 = "CgkI95yh8ZUVEAIQIg";
	const string ID_ACH_31 = "CgkI95yh8ZUVEAIQIw";
	#endregion

	#region ACH. REQs
	const int TOTAL_BALLS_FOR_ACH_2 = 10;
	const int TOTAL_BALLS_FOR_ACH_5 = 20;
	const int TOTAL_BALLS_FOR_ACH_8 = 40;
	const int TOTAL_BALLS_FOR_ACH_11 = 75;
	const int TOTAL_BALLS_FOR_ACH_14 = 100;
	const int TOTAL_BALLS_FOR_ACH_17 = 150;
	const int TOTAL_BALLS_FOR_ACH_20 = 200;
	const int TOTAL_BALLS_FOR_ACH_23 = 275;
	const int TOTAL_BALLS_FOR_ACH_26 = 375;
	const int TOTAL_BALLS_FOR_ACH_29 = 500;

	const int SCORE_FOR_ACH_1 = 10;
	const int SCORE_FOR_ACH_4 = 20;
	const int SCORE_FOR_ACH_7 = 30;
	const int SCORE_FOR_ACH_10 = 40;
	const int SCORE_FOR_ACH_13 = 50;
	const int SCORE_FOR_ACH_16 = 75;
	const int SCORE_FOR_ACH_19 = 100;
	const int SCORE_FOR_ACH_22 = 125;
	const int SCORE_FOR_ACH_25 = 150;
	const int SCORE_FOR_ACH_28 = 175;
	const int SCORE_FOR_ACH_31 = 250;

	const int BALLS_FOR_ACH_3 = 3;
	const int BALLS_FOR_ACH_6 = 5;
	const int BALLS_FOR_ACH_9 = 7;
	const int BALLS_FOR_ACH_12 = 10;
	const int BALLS_FOR_ACH_15 = 13;
	const int BALLS_FOR_ACH_18 = 17;
	const int BALLS_FOR_ACH_21 = 20;
	const int BALLS_FOR_ACH_24 = 25;
	const int BALLS_FOR_ACH_27 = 30;
	const int BALLS_FOR_ACH_30 = 40;
	#endregion

	string[] achTXTs;
	
	char[] achievements;
	bool allScores = false;
	bool allTotalBalls = false;
	bool allBalls = false;

	public int totalBalls = 0;

	private static AchievementHandler instance = null;
	public static AchievementHandler Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(transform.gameObject);
		fetchAchievements();
		fillAchTXTs();
	}

	void Start() {
		PlayGamesPlatform.Activate();
	}

	public void fetchAchievements() {
		allScores = PlayerPrefs.GetInt("allScores", 0) == '1';
		allTotalBalls = PlayerPrefs.GetInt("allTotalBalls", 0) == '1';
		allBalls = PlayerPrefs.GetInt("allBalls", 0) == '1';

//		if(!(allScores && allBalls && allTotalBalls)) {
		string achievementsString = PlayerPrefs.GetString("achievements", "10000000000000000000000000000000");
//		Debug.Log("AchString: '" + achievementsString + "'");
		achievements = achievementsString.ToCharArray();
		totalBalls = PlayerPrefs.GetInt("totalBalls");

		if(!(allScores && allBalls && allTotalBalls))
			checkIfAllDone();
	}

	public void storeAchievements() {
		if((achievements != null) && achievements.Length > 30) {
			PlayerPrefs.SetString("achievements", new string(achievements));
//			Debug.Log("-->New Ach String in store: '" + new string(achievements) + "'");
		}
	}


	/** TODO */
	void syncAchievements() {
//		for(int i = 0; i < achievements.Length; i++) {
//
//		}
	}

	void checkIfAllDone() {
		int i;
		if(!allScores) {
			for(i = 1; i < achievements.Length; i+=3) {
				if(achievements[i] == '0') {
					allScores= false;
					break;
				}
			}
			allScores = (i >= achievements.Length);
			if(allScores) PlayerPrefs.SetInt("allScores", 1);
		}

		if(!allTotalBalls) {
			for(i = 2; i < achievements.Length; i+=3) {
				if(achievements[i] == '0') {
					allTotalBalls= false;
					break;
				}
			}
			allTotalBalls = (i >= achievements.Length);
			if(allTotalBalls) PlayerPrefs.SetInt("allTotalBalls", 1);
		}

		if(!allBalls) {
			for(i = 3; i < achievements.Length; i+=3) {
				if(achievements[i] == '0') {
					allBalls= false;
					break;
				}
			}
			allBalls = (i >= achievements.Length);
			if(allBalls) PlayerPrefs.SetInt("allBalls", 1);
		}
	}

	public bool checkAchievement(int achID) {
//		Debug.Log("Checking ach " + achID + ": " + achievements[achID]);
		if(achievements.Length < achID+1) {
			fetchAchievements();
//			Debug.Log("Achievements array not filled");
		}
//		Debug.Log("Checking ach " + achID + ": " + achievements[achID]);
		return achievements[achID] == '1';
	}

	public string getAchTXT(int achID) {
		if((achID % 3) == 2)
			return totalBalls + "" + achTXTs[achID];
		else
			return achTXTs[achID];
	}

	public void submitTotalBalls(int newBalls) {
		totalBalls += newBalls;
		PlayerPrefs.SetInt("totalBalls", newBalls);
	}

	public void tryScore(int score) {
		#region tryScore
		if(!allScores) {
			if(achievements[1] == '0' && (score >= SCORE_FOR_ACH_1)) {;
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_1, 100.0f, (bool success)=>{});
				achievements[1] = '1';
			}
			if(achievements[4] == '0' && (score >= SCORE_FOR_ACH_4)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_4, 100.0f, (bool success)=>{});
				achievements[4] = '1';
			}
			if(achievements[7] == '0' && (score >= SCORE_FOR_ACH_7)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_7, 100.0f, (bool success)=>{});
				achievements[7] = '1';
			}
			if(achievements[10] == '0' && (score >= SCORE_FOR_ACH_10)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_10, 100.0f, (bool success)=>{});
				achievements[10] = '1';
			}
			if(achievements[13] == '0' && (score >= SCORE_FOR_ACH_13)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_13, 100.0f, (bool success)=>{});
				achievements[13] = '1';
			}
			if(achievements[16] == '0' && (score >= SCORE_FOR_ACH_16)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_16, 100.0f, (bool success)=>{});
				achievements[16] = '1';
			}
			if(achievements[19] == '0' && (score >= SCORE_FOR_ACH_19)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_19, 100.0f, (bool success)=>{});
				achievements[19] = '1';
			}
			if(achievements[22] == '0' && (score >= SCORE_FOR_ACH_22)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_22, 100.0f, (bool success)=>{});
				achievements[22] = '1';
			}
			if(achievements[25] == '0' && (score >= SCORE_FOR_ACH_25)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_25, 100.0f, (bool success)=>{});
				achievements[25] = '1';
			}
			if(achievements[28] == '0' && (score >= SCORE_FOR_ACH_28)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_28, 100.0f, (bool success)=>{});
				achievements[28] = '1';
			}
		}
		#endregion
	}

	public void tryBalls(int newBalls) {
		#region tryBalls
		if(!allBalls) {
			if(achievements[3] == '0' && (newBalls >= BALLS_FOR_ACH_3)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_3, 100.0f, (bool success)=>{});
				achievements[3] = '1';
			}
			if(achievements[6] == '0' && (newBalls >= BALLS_FOR_ACH_6)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_6, 100.0f, (bool success)=>{});
				achievements[6] = '1';
			}
			if(achievements[9] == '0' && (newBalls >= BALLS_FOR_ACH_9)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_9, 100.0f, (bool success)=>{});
				achievements[9] = '1';
			}
			if(achievements[12] == '0' && (newBalls >= BALLS_FOR_ACH_12)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_12, 100.0f, (bool success)=>{});
				achievements[12] = '1';
			}
			if(achievements[15] == '0' && (newBalls >= BALLS_FOR_ACH_15)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_15, 100.0f, (bool success)=>{});
				achievements[15] = '1';
			}
			if(achievements[18] == '0' && (newBalls >= BALLS_FOR_ACH_18)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_18, 100.0f, (bool success)=>{});
				achievements[18] = '1';
			}
			if(achievements[21] == '0' && (newBalls >= BALLS_FOR_ACH_21)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_21, 100.0f, (bool success)=>{});
				achievements[21] = '1';
			}
			if(achievements[24] == '0' && (newBalls >= BALLS_FOR_ACH_24)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_24, 100.0f, (bool success)=>{});
				achievements[24] = '1';
			}
			if(achievements[27] == '0' && (newBalls >= BALLS_FOR_ACH_27)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_27, 100.0f, (bool success)=>{});
				achievements[27] = '1';
			}
			if(achievements[30] == '0' && (newBalls >= BALLS_FOR_ACH_30)) {
				if (Social.localUser.authenticated) Social.ReportProgress(ID_ACH_30, 100.0f, (bool success)=>{});
				achievements[30] = '1';
			}
		}
		#endregion
	}

	/**update total before call to this method**/
	public void tryTotalBalls(int newBalls) {
		#region tryTotalBalls
		if(!allTotalBalls) {
			if(achievements[2] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_2, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_2) achievements[2] = '1';
			}
			if(achievements[5] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_5, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_5) achievements[5] = '1';
			}
			if(achievements[8] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_8, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_8) achievements[8] = '1';
			}
			if(achievements[11] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_11, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_11) achievements[11] = '1';
			}
			if(achievements[14] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_14, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_14) achievements[14] = '1';
			}
			if(achievements[17] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_17, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_17) achievements[17] = '1';
			}
			if(achievements[20] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_20, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_20) achievements[20] = '1';
			}
			if(achievements[23] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_23, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_23) achievements[23] = '1';
			}
			if(achievements[26] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_26, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_26) achievements[26] = '1';
			}
			if(achievements[29] == '0') {
				if (Social.localUser.authenticated) ((PlayGamesPlatform)Social.Active).IncrementAchievement(ID_ACH_29, newBalls, (bool success)=>{});
				if (totalBalls >= TOTAL_BALLS_FOR_ACH_29) achievements[29] = '1';
			}
		}
		#endregion
	}

	void fillAchTXTs() {
		achTXTs = new string[32];
		achTXTs[0] = "ERROR LOADING";
		achTXTs[1] = "Get a score of 10";
		achTXTs[2] = " of 10 footballs";
		achTXTs[3] = "3 footballs in one sprint";
		achTXTs[4] = "Get a score of 20";
		achTXTs[5] = " of 20 footballs";
		achTXTs[6] = "5 footballs in one sprint";
		achTXTs[7] = "Get a score of 30";
		achTXTs[8] = " of 40 footballs";
		achTXTs[9] = "7 footballs in one sprint";
		achTXTs[10] = "Get a score of 40";
		achTXTs[11] = " of 75 footballs";
		achTXTs[12] = "10 footballs in one sprint";
		achTXTs[13] = "Get a score of 50";
		achTXTs[14] = " of 100 footballs";
		achTXTs[15] = "13 footballs in one sprint";
		achTXTs[16] = "Get a score of 75";
		achTXTs[17] = " of 150 footballs";
		achTXTs[18] = "17 footballs in one sprint";
		achTXTs[19] = "Get a score of 100";
		achTXTs[20] = " of 200 footballs";
		achTXTs[21] = "20 footballs in one sprint";
		achTXTs[22] = "Get a score of 125";
		achTXTs[23] = " of 275 footballs";
		achTXTs[24] = "25 footballs in one sprint";
		achTXTs[25] = "Get a score of 150";
		achTXTs[26] = " of 375 footballs";
		achTXTs[27] = "30 footballs in one sprint";
		achTXTs[28] = "Get a score of 175";
		achTXTs[29] = " of 500 footballs";
		achTXTs[30] = "40 footballs in one sprint";
		achTXTs[31] = "Get a score of 250";
	}

	public void unlockFirst() {
		if(Social.localUser.authenticated)
			Social.ReportProgress(ID_ACH_0, 100.0f, (bool success)=>{});
	}

	void OnDisable() {
		storeAchievements();
	}

	public void RESET_PLAYER_PREFS() {
			PlayerPrefs.SetString("achievements", "10000000000000000000000000000000");
//			PlayerPrefs.SetString("achievements", "11111111111111111111111111111111");
			PlayerPrefs.SetInt("allScores", 0);
			PlayerPrefs.SetInt("allTotalBalls", 0);
			PlayerPrefs.SetInt("allBalls", 0);

			PlayerPrefs.SetInt("mostBalls",0);
			PlayerPrefs.SetInt("highscore",0);
			PlayerPrefs.SetInt("totalBalls",0);

			PlayerPrefs.SetInt("fromGame", 0);
			PlayerPrefs.SetInt("numLaunches", 0);
			PlayerPrefs.SetInt("musicEnabled", 1);

			PlayerPrefs.SetInt("curChar", 0);
        }
}