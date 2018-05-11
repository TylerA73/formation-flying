using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Author: Tyler Arseneault
 * Due:
 * Description: Controller for the player controlled Jet.
 * This allows the player to control the pitch, yaw, and speed of the jet.
 */
public class JetController : MonoBehaviour {

	private Rigidbody rbody; //rigidbody of the jet
	private Transform transform; //transform of the jet
	public float rotateSpeed; //how fast the jet rotates on either axis for pitch and yaw

	public float speed; //speed of the jet

	/**
	 * Initializes some of the important components of the jet for use
	 */
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
	}
	
	/**
	 * Updates the jet every frame
	 */
	void Update () {

		Movement ();

	}

	/**
	 * Controls the movements of the jet through the air
	 */
	void Movement(){

		AdjustSpeed ();

		rbody.velocity = transform.forward * speed;

		AdjustRotation ();

	}

	/**
	 * Changes the speed of the jet when the scroll wheel is moved up or down
	 */
	void AdjustSpeed(){

		speed += Input.GetAxis ("Mouse ScrollWheel");
		if (speed < 10) {
			speed = 10;
		} else if (speed > 50) {
			speed = 50;
		}

	}

	/**
	 * Alters the direction of the jet based on key presses
	 */
	void AdjustRotation(){
	
		if (Input.GetKey (KeyCode.D))
			transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);
		else if (Input.GetKey (KeyCode.A))
			transform.Rotate (Vector3.down * rotateSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.W))
			transform.Rotate (Vector3.right * rotateSpeed * Time.deltaTime);
		else if (Input.GetKey (KeyCode.S))
			transform.Rotate (Vector3.left * rotateSpeed * Time.deltaTime);
	
	}
}
