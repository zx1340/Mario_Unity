using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		

		//print ("enemy enter2d with" + col.gameObject.tag);

		if (col.gameObject.tag == "player") {
				//print ("player meet enemy " + other.gameObject.);
				switch (PlayerControler.PlayerState) {
				case 2:
					PlayerControler.PlayerState = 1;
					break;
				case 1:
					PlayerControler.PlayerState = 0;
					break;
				case 0:
					Destroy (col.gameObject);
					break;
				}
				
				Destroy (gameObject);


		
		}
	}


}
