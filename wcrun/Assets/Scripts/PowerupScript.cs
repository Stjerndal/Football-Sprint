using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour {
	
	public GameScreenController gameScreenController;
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player") {
			gameScreenController = GameObject.Find ("Main Camera").GetComponent<GameScreenController>(); //TODO INNEFFICIENT!!!!! DO ONCE!!
			gameScreenController.CollectBall();
			Destroy(this.gameObject);
		}
	}

}
