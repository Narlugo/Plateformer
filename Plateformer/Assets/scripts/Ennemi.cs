using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : Ennemies {

	public GameObject point1;
	public GameObject point2;

	public float speed = 5f;

	private bool detection = false;
    

	public Transform player;

	private new Rigidbody2D rigidbody;

	private float xDirection = 1;

	// Use this for initialization
	void Start() {
        health = 3;
        rangeDetection = 5f;
		rigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 nVel = rigidbody.velocity;

		if (Vector2.Distance(player.position, transform.position) <= rangeDetection) {
			detection = true;
			if (transform.position.x > player.position.x) {
				transform.rotation = Quaternion.Euler(0f, 180f, 0f);
				xDirection = -1f;
			} else {
				transform.rotation = Quaternion.Euler(0f, 0f, 0f);
				xDirection = 1f;
			}
		} else {
			detection = false;
		}

		if (!detection) {
			if (transform.position.x <= point1.transform.position.x) {
				xDirection = 1f;
			}

			if (transform.position.x >= point2.transform.position.x) {
				xDirection = -1f;
			}
		}

		nVel.x = speed * xDirection;
		rigidbody.velocity = nVel;
	}

	
}
