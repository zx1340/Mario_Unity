using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControler : MonoBehaviour {

	public float speed = 5f;
	public float height = 20f;
	public bool grounded = false;
	public static int PlayerState;
	private Rigidbody2D rb;
	public Color BaseColor;
	public Color FPowerColor;
	public Renderer pc;

	public GameObject Bullet;

	public bool facingRight = true;	
	public bool canFire = false;

	public float fireRate = 0.3f;

	private float nextFire;

	public float distToGround;
	private Animator animator;
	const string animationState = "walking";


	public AudioClip eatgold;
	public AudioClip killenemy;
	public AudioClip downlevel;
	public AudioClip eatmushroom;
	public AudioClip nextlevel;
	public AudioClip die;



	AudioSource audio;



	void Start(){
		//setup rigit body
		PlayerState = 0;
		rb = GetComponent<Rigidbody2D> ();
		pc = gameObject.GetComponent<Renderer> ();
		animator = GetComponent<Animator>();
		animator.SetBool(animationState,false);
		audio = GetComponent<AudioSource> ();
	}

	void State(){

		if (PlayerState < 0) {
			Destroy (gameObject);
			SceneManager.LoadScene ("Menu");
		
		}

		if (PlayerState == 0) {
			//do nothing
			Vector3 theScale = transform.localScale;

			transform.localScale = new Vector3 (theScale.x, 0.3f, 1f);
			transform.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f); 
			canFire = false;

		}
		if (PlayerState == 1) {
			Vector3 theScale = transform.localScale;

			transform.localScale = new Vector3 (theScale.x, 0.6f, 1f);
			transform.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f); 
			canFire = false;
		}

		if (PlayerState == 2) {

			Vector3 theScale = transform.localScale;
			transform.localScale = new Vector3 (theScale.x, 0.6f, 1f);
			transform.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f); 
			canFire = true;
		}

	}


	// Update is called once per frame
	void FixedUpdate () {
		State ();


		if (Input.GetKey (KeyCode.RightArrow) || (Input.GetKey(KeyCode.D))) {

			transform.Translate (Vector3.right * speed * Time.fixedDeltaTime);
			if(facingRight == false){
				Flip ();
			}
			animator.SetBool(animationState,true); //for Walk
		}
		if (Input.GetKey (KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A))) {
			transform.Translate (Vector3.left * speed * Time.fixedDeltaTime);
			if (facingRight == true) {
				Flip ();
			}
			animator.SetBool(animationState,true);
		}
		if (Input.GetKey (KeyCode.UpArrow)  || (Input.GetKey (KeyCode.W))) {
			
			if (grounded == true) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0f, height);
			}
			animator.SetBool(animationState,false);
		}
		if( (Input.GetKey (KeyCode.Space))){
			if (canFire == true  && Time.time > nextFire){ 
				nextFire = Time.time + fireRate;
				if(facingRight == true)
				{
					// ... instantiate the rocket facing right and set it's velocity to the right. 
					Instantiate (Bullet, transform.position, Quaternion.Euler (new Vector3 (0, 0, 1)));
				}
				else
				{
					// Otherwise instantiate the rocket facing left and set it's velocity to the left.
					Instantiate (Bullet, transform.position, Quaternion.Euler (new Vector3 (0, 0, -180)));
				}
					
			}
			animator.SetBool(animationState,false);
		}


		if(Input.anyKey == false)
		{
			animator.SetBool(animationState,false); //for Walk
		}



			
	}



	void OnTriggerEnter2D(Collider2D other){
		print ("Player enter collider 2d:" + other.gameObject.tag);

		if (other.gameObject.tag == "mushroom") {
		
			switch (PlayerState) {
			case 0:
				PlayerState = 1;
				audio.PlayOneShot (nextlevel,1f);
				break;
			case 1:
				PlayerState = 1;
				break;
			case 2:
				PlayerState = 2;
				break;
			default:
				break;
			}
		}

		if (other.gameObject.tag == "fireflower") {
			PlayerState = 2;
			audio.PlayOneShot (nextlevel,1f);
		}



		if (other.gameObject.tag == "Coin") {
			audio.PlayOneShot (eatgold,1f);
		}


		if (other.gameObject.tag == "Ground") {
			grounded = true;
		} 

		if (other.gameObject.tag == "enemy_weak") {
			
			audio.PlayOneShot (killenemy,1f);
			Destroy(other.transform.parent.gameObject);
		
		}
		if (other.gameObject.tag == "enemy_shell") {
			audio.PlayOneShot (downlevel,1f);
		
			Destroy(other.transform.parent.gameObject);
			PlayerState = PlayerState - 1;
		}
		if (other.gameObject.tag == "levelend") {
			

			SceneManager.LoadScene ("Mario 1");
		}

		if (other.gameObject.tag == "deadzone") {
			audio.PlayOneShot (die,1f);

		
			SceneManager.LoadScene ("Menu");
		}
			
	}
	void OnTriggerExit2D(Collider2D other){
		//print ("Player exit 2D" + other.gameObject.tag);
		if (other.gameObject.tag == "Ground") {
			grounded = false;
		}
		grounded =false;
	}
	void OnTriggerStay2D(Collider2D other){
		//print ("Player stay 2D" + other.gameObject.tag);
		if (other.gameObject.tag == "Ground") {
			grounded = true;
		}
	}

	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		print("TRANFORM" + facingRight.ToString());
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
