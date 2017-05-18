using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomScript : MonoBehaviour {

	public float speed = 5f;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "player") {
			if (PlayerControler.PlayerState == 0) {
				PlayerControler.PlayerState = 1;
			}
			Destroy (this.gameObject);
		}
	}
	void Update(){
		//print ("MUSHROOM LAYER" + gameObject.layer);
		transform.Translate (Vector3.right * speed * Time.fixedDeltaTime);
		Physics2D.IgnoreLayerCollision (9, 10);
		//Physics2D.IgnoreLayerCollision (9, 10);

	}
}
