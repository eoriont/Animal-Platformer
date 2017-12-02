using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimal : MonoBehaviour {

    GameObject bear;
    public string state = "bear";

	// Use this for initialization
	void Start () {
        bear = GameObject.Find ("Bear");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3 (transform.position.x, bear.transform.position.y, transform.position.z);
        Ray ray = new Ray (pos, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            if (hit.transform.gameObject == bear && state == "bear") {
                AnimalSwitch s = GetComponent<AnimalSwitch> ();
                s.Switch (s.Bear, s.Bird);
            }
        }
	}
}
