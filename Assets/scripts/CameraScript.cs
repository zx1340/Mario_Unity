using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {


	public Transform player;
	public GameObject LevelStart;
	public GameObject LevelEnd;

	float Campos;
	float min;
	float max;

	// Use this for initialization
	void Start () {
		min = LevelStart.transform.position.x + 9.9f;
		max = LevelEnd.transform.position.x - 9.9f;
	}
	
	// Update is called once per frame
	void Update () {
		if (player) {
			Campos = player.transform.position.x + 1.6f;
			gameObject.transform.position = new Vector3 (Mathf.Clamp (Campos, min, max), gameObject.transform.position.y, gameObject.transform.position.z);
		}
	}
}
