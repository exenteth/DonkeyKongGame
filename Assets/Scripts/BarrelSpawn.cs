using UnityEngine;
using System.Collections;

public class BarrelSpawn : MonoBehaviour {

	public GameObject barrel;
	public float spawnTime = 3f;
	public Transform spawnPoint;
	
	
	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		Instantiate (barrel, spawnPoint.position, spawnPoint.rotation);
	}
}
