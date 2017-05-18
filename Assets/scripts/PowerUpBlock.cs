using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBlock : MonoBehaviour {

	public GameObject Mushroom;
	public GameObject FireFlower;
	public GameObject Spawn;

	void OnTriggerEnter2D(){
		print ("Powerblock trigger enter2d");
		if (PlayerControler.PlayerState == 0) {
			Instantiate (Mushroom, Spawn.transform.position, Quaternion.identity);
		} else if (PlayerControler.PlayerState >= 1) {		
			Instantiate (FireFlower, Spawn.transform.position, Quaternion.identity);
		}
		Destroy (this);
	}

}
