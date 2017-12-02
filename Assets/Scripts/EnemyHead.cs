using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour {

    public GameObject enemy;

    public void Die() {
        enemy.GetComponent<EnemySnail> ().Die ();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision) {
        Debug.Log ("Collided");
        if (collision.collider.gameObject.tag == "Player") {
            Die ();
        }
    }
}
