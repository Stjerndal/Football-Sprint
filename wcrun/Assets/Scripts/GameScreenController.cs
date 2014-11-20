using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class GameScreenController : MonoBehaviour {

	private const string leaderboardID = "CgkI95yh8ZUVEAIQBw";

	public Vector2 playerSpawnPos;
	public float defaultGravityScale;
	int bestScore;
	int mostBalls;

	bool running;
	bool runningPoints;

	public float playerScore = 0;
	int balls = 0;

	public CameraRunnerScript cameraRunnerScript;

	public CharSelector charSelect;

	public GUIText scoreTextField;
	public GUIText finalScoreField;
	public GUIText bestScoreField;

	public GameObject gameOverContainer;

	GameObject character;
	public Platformer2DUserControl userControl;
	public PlatformerCharacter2D charScript;
	public SpawnScript[] spawners;

//	public GameObject spawnGround;
//	public Vector2 spawnGroundPos;
	public MoverScript spawnerContainer;
	public Vector2 defaultSpawnPos;
	public Transform bgGround1;
	public Vector2 bgGround1Spawn;
	public Transform bgGround2;
	public Vector2 bgGround2Spawn;

	public float charPosPointStart;

	public BannerAd bannerAd;

	public AchievementHandler achHandler;

	public int curChar;

	PlayerAudio playerAudio;

	// Use this for initialization
	void Start () {
		PlayGamesPlatform.Activate();
		bannerAd.Load ();
		bannerAd.hide ();

		achHandler = GameObject.FindObjectOfType<AchievementHandler>();

		mostBalls = PlayerPrefs.GetInt("mostBalls");
		bestScore = PlayerPrefs.GetInt("highscore");
		bestScoreField.text = "" + bestScore;
		curChar = PlayerPrefs.GetInt("curChar");
//		curChar = 1;
		character = (GameObject) Instantiate(charSelect.characters[curChar],
		                                     playerSpawnPos, Quaternion.identity);

		cameraRunnerScript.setChar(character.transform);
		userControl = character.GetComponent<Platformer2DUserControl>();
		charScript = character.GetComponent<PlatformerCharacter2D>();
		playerAudio = GameObject.FindObjectOfType<PlayerAudio>();

		running = true;
		runningPoints = false;
	}
	

	
	// Update is called once per frame
	void Update () {
		if(runningPoints)
			playerScore += Time.deltaTime;
		else if ((character.transform.position.x > charPosPointStart) && running)
			runningPoints = true;

	}
	
	public void CollectBall() {
		playerAudio.Collect();
		playerScore += 3;
		balls++;
	}
	
	void OnGUI() {
		if(running)
			scoreTextField.text = "Score:" + (int)(playerScore);
	}

	public void RestartGame ()
	{
		character.transform.position = playerSpawnPos;
		character.rigidbody2D.gravityScale = defaultGravityScale;
		cameraRunnerScript.forceUpdate();
		//charBody.position = playerSpawnPos;
		//charBody.gravityScale = defaultGravityScale;
		userControl.dead = false;
		charScript.dead = false;

		GameObject[] enviroments = GameObject.FindGameObjectsWithTag("Enviroment");
		foreach(GameObject enviroment in enviroments) {
			Destroy(enviroment);
		}



//		Instantiate(spawnGround, spawnGroundPos, Quaternion.identity);

		bgGround1.position = bgGround1Spawn;
		bgGround2.position = bgGround2Spawn;

		gameOverContainer.SetActive(false);
		bannerAd.hide();

		balls = 0;
		playerScore = 0;
		scoreTextField.enabled = true;
		running = true;

		foreach(SpawnScript spawner in spawners) {
			spawner.Reset();
			//spawner.SpawnWithDelay(0.2f);
		}
		spawnerContainer.Restart(defaultSpawnPos);
	}



	public void GameOver() {
		running = false;
		runningPoints = false;
		playerAudio.Die();
		//TODO Plain text file, better to keep a packet with the score in it
		//persist that, using a DontDestroyOnLoad.
		//int best = PlayerPrefs.GetInt("highscore");
		if(((int)playerScore) > bestScore) {
			//TODO POPUP NEW HIGHSCORE!!!
			bestScore = (int) playerScore;
			achHandler.tryScore(bestScore);
			PlayerPrefs.SetInt("highscore", bestScore);

			if (Social.localUser.authenticated) {
				Social.ReportScore(bestScore, leaderboardID, (bool success) => {});
			}

		}

		if(balls > mostBalls) {
			mostBalls = balls;
			PlayerPrefs.SetInt("mostBalls", mostBalls);
			achHandler.tryBalls(mostBalls);
		}


		character.rigidbody2D.position = new Vector2(character.rigidbody2D.position.x, -50);
		character.rigidbody2D.gravityScale = 0;
		character.rigidbody2D.velocity = new Vector2(0, 0);


		userControl.dead = true;
		charScript.dead = true;

		foreach(SpawnScript spawner in spawners) {
			spawner.running = false;
		}

		finalScoreField.text = "" + ((int) playerScore);
		bestScoreField.text = "" + bestScore;
		scoreTextField.enabled = false;
		gameOverContainer.SetActive(true);

//		achHandler.tryScore(bestScore);
//		achHandler.tryBalls(mostBalls);
		achHandler.submitTotalBalls(balls);
		achHandler.tryTotalBalls(balls);

		spawnerContainer.StopMoving();
		bannerAd.show();

	}

	public void OnDisable () {
		bannerAd.kill();
		achHandler.storeAchievements();
    }
}
