using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlowerScript : MonoBehaviour {

	void OnTriggerEnter2D(){

		Destroy (this.gameObject);
	}

	void Update(){
		Physics2D.IgnoreLayerCollision (8, 9);
	}

}
