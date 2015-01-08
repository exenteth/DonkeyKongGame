using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public PlayerMove player;
    public Transform playerTransform;
    public Vector3 cameraOffset;
    public float smoothing = 100f;
    public float zoom = 1f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(player.isDead)
        {
            Vector3 relativePos = playerTransform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smoothing);
 
            //transform.LookAt(playerTransform.position, Vector3.up);
            Camera cam = GetComponent<Camera>();
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, zoom, smoothing * Time.deltaTime);
        }
	}
}
