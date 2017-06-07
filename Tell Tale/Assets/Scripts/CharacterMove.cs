using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

	public float moveSpeed;
	public float rotateSpeed;
	public float jumpSpeed;
	public bool onLeiter;

	bool isGrounded;

	// Use this for initialization
	void Start ()
	{
	}

	// FixedUpdate is called once per frame for Physics updates
	void FixedUpdate ()
	{
		// check ground
		isGrounded = Physics.Raycast (transform.position, -transform.up, transform.localScale.y + 0.1f);

		// input
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (!Input.GetButton ("Fire1")) {
			// movement
			transform.Rotate (Vector3.up * h * rotateSpeed * Time.deltaTime);
			if (onLeiter == true) { 
				Debug.Log ("Spieler in der Trigger-Zone der Leiter.");

				transform.Translate (new Vector3 (0, v, 0) * Time.deltaTime * moveSpeed);
			} else {
				transform.Translate (new Vector3 (0, 0, v) * Time.deltaTime * moveSpeed);
			}

		} else if (isGrounded) {
			// TODO drill
		}

		// jump
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			GetComponent<Rigidbody> ().AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
		}

		// TODO duck


	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Leiter") {
			GetComponent<Rigidbody> ().useGravity = false;
			onLeiter = true;

		}
	}

	void OnTriggerExit (Collider other)
	{
		GetComponent<Rigidbody> ().useGravity = true;
		onLeiter = false;

	}

		
}
