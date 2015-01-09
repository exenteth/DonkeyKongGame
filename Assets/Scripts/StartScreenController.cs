using UnityEngine;
using System.Collections;

public class StartScreenController : MonoBehaviour {

    private bool readyToStart = false;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (readyToStart)
        {
            if (Input.GetButton("Jump"))
            {
                Application.LoadLevel("level_01");
            }
        }
	}

    void EnableStart()
    {
        readyToStart = true;
    }
}
