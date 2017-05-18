using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	public float speed = 5f;

	// Update is called once per frame
	void FixedUpdate()
	{
		transform.Translate (Vector2.left * speed * Time.fixedDeltaTime);
		Physics2D.IgnoreLayerCollision (10,11);
	}
}
