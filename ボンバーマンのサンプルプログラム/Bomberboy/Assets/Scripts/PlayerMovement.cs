using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private Animator animator;

	public override void OnStartLocalPlayer() {
		GetComponent<SpriteRenderer> ().color = Color.red;
	}

	void FixedUpdate () {
		if (this.isLocalPlayer) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D> ().velocity;

			float newVelocityX = 0f;
			if (moveHorizontal < 0 && currentVelocity.x <= 0) {
				newVelocityX = -speed;
				animator.SetInteger ("DirectionX", -1);
			} else if (moveHorizontal > 0 && currentVelocity.x >= 0) {
				newVelocityX = speed;
				animator.SetInteger ("DirectionX", 1);
			} else {
				animator.SetInteger ("DirectionX", 0);
			}

			float newVelocityY = 0f;
			if (moveVertical < 0 && currentVelocity.y <= 0) {
				newVelocityY = -speed;
				animator.SetInteger ("DirectionY", -1);
			} else if (moveVertical > 0 && currentVelocity.y >= 0) {
				newVelocityY = speed;
				animator.SetInteger ("DirectionY", 1);
			} else {
				animator.SetInteger ("DirectionY", 0);
			}

			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (newVelocityX, newVelocityY);
		}
	}
}
