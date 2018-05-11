using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *
 * Author: Tyler Arseneault
 * Due:
 * Description: Controller for the follower jets.
 * The follower jets will follow specific points attached to
 * the lead jet. Their speed will increase and decrease with the lead jet.
 *
 */
public class AIController : MonoBehaviour {

	public Transform target; //transform of the target gameobject
	private Transform transform; //transform of the AI
	private Rigidbody rbody; //rigidbody of the AI

	/**
	 * Initializes important components for the AI
	 */
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		transform = GetComponent<Transform> ();
	}

	/**
	 * Updates the AI every frame
	 */
	void Update () {

		//ensures that the AI remains at the same speed as the lead jet
		float speed = target.GetComponentInParent<JetController> ().speed;
		rbody.velocity = transform.forward * speed;

		//calculate the location of the target compared to the AI
		//move the AI in the direction of the target
		Vector3 location = target.position - transform.position;
		Vector3 heading = rbody.velocity;
		rbody.velocity = Vector3.RotateTowards (heading, location, 60f, 0f);
		transform.LookAt (target); //always look at the target

	}
}
