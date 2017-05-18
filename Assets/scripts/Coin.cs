using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	int CoinValue = 100;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			ScoreManager.score += CoinValue;
			Destroy (gameObject);
		}

	}
	void Update(){
		Physics2D.IgnoreLayerCollision (9, 10);
	}
		

}
