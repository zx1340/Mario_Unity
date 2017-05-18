using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerScript : MonoBehaviour {

	void OnTriggerEnter2D(){

		PlayerControler.PlayerState = 2;
		Destroy (this.gameObject);
	}

	void Update(){
		Physics2D.IgnoreLayerCollision (8, 9);
	}

}
