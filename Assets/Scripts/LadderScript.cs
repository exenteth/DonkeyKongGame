using UnityEngine;
using System.Collections;

public class LadderScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           PlayerMove script = other.gameObject.GetComponent<PlayerMove>();
           script.EnterLadderArea(getChildGameObject(this.gameObject, "TopLocation").transform,
               getChildGameObject(this.gameObject, "BottomLocation").transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerMove script = other.gameObject.GetComponent<PlayerMove>();
            script.LeaveLadderArea();
        }
    }

    GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        //Author: Isaac Dart, June-13.
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
}
