using UnityEngine;
using System.Collections;

public class Catch : MonoBehaviour {

	void OnTriggerEnter(Collider other) 
	{
		other.isTrigger = false;
	}
}
