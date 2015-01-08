using UnityEngine;
using System.Collections;

public class Falling : MonoBehaviour {

	Vector3 fall;

	void FixedUpdate () {
		if (rigidbody.velocity.y < -1f) {
			fall.Set (0f, rigidbody.velocity.y, rigidbody.velocity.z);
			rigidbody.velocity = fall;
		}
	}
}
