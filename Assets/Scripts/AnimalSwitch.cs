using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSwitch : MonoBehaviour {

    public GameObject Bear;
    public GameObject Bird;

	// Use this for initialization
	void Start () {
        Bear = GameObject.Find ("Bear");
        Bird = GameObject.Find ("Bird");

        Bird.SetActive (false);
	}

    public void Switch(GameObject a1, GameObject a2) {
        a1.SetActive (false);
        a2.transform.position = a1.transform.position;
        a2.SetActive (true);
        Camera.main.gameObject.GetComponent<CameraController> ().obj = a2;
        Debug.Log ("Switched from " + a1.name + " to " + a2.name);
    }
}
