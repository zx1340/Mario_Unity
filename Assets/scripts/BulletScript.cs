using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	public float speed = 7f;
	// Update is called once per frame
	private PlayerControler player;
	void Start(){
		AudioSource audio = gameObject.AddComponent < AudioSource > ();
		audio.PlayOneShot ((AudioClip)Resources.Load ("shot_player")); 

		Destroy(gameObject, 3);
		player = transform.root.GetComponent<PlayerControler>();
	}

	void FixedUpdate()
	{
//		if (player.facingRight == true) {
			transform.Translate (Vector2.right * speed * Time.fixedDeltaTime);
//
//		
//		
//		}
//		if (player.facingRight == false) {
//			transform.Translate (Vector2.left * speed * Time.fixedDeltaTime);
//		
//		
//		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "enemy") {
			print ("Bullet hit enemy");
			AudioSource audio = gameObject.AddComponent < AudioSource > ();
			audio.PlayOneShot ((AudioClip)Resources.Load ("explosion")); 

			Destroy (other.gameObject);
		}

	}
}
