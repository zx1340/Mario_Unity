using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveEnemy : MonoBehaviour {
	public float speed = 2f;
	GameObject startMove;
	GameObject endmove;
	bool state = true;
	public int enemy_type;

	// Update is called once per frame
	void FixedUpdate()
	{

		if (state) {

			transform.Translate (Vector2.left * speed * Time.fixedDeltaTime);
			Physics2D.IgnoreLayerCollision (10, 11);
		} else {
	
			transform.Translate (Vector2.right * speed * Time.fixedDeltaTime);
			Physics2D.IgnoreLayerCollision (10, 11);

	
		}

	}
	void OnTriggerEnter2D(Collider2D col){

		if (enemy_type == 1) {
			if (col.gameObject.tag == "enemymove") {
				Flip ();
			}
		}
		if (enemy_type == 0) {
			if (col.gameObject.name == "Block_Ground") {
				Flip ();	
			}
		}

	}

	void Flip ()
	{
		state = !state;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
