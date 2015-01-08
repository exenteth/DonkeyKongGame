using UnityEngine;
using System.Collections;

public class Fall : MonoBehaviour {

	public float timeBetweenFalls = 1f;
	public GameObject player;
	float timer;


	bool fallingActive = false;

	void Update() 
	{
		timer += Time.deltaTime;

		if(timer > timeBetweenFalls) 
		{
			fallingActive = !fallingActive;
			timer = 0f;
		}

	}

	void OnTriggerEnter(Collider other) 
	{
		if (fallingActive) 
		{
			if(other.gameObject != player) 
			{
				other.isTrigger = true;
			}
		}
	}
}
