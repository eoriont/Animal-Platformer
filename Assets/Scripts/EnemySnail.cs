using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnail : MonoBehaviour {

    public GameObject shell;

    public float direction;
    public float speed = .04f;
    public float maxMoveSpeed = 1;

    int life = 2;

	// Use this for initialization
	void Start () {
        direction = 1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate (transform.right * direction * speed);
    }

    public void Die() {
        Debug.Log ("Die");
        life--;
        if (life == 1) {
            shell.SetActive (false);
        }
        if (life == 0) {
            gameObject.SetActive (false);
        }
        
    }

    public void Respawn() {
        life = 2;
        gameObject.SetActive (true);
        shell.SetActive (true);
    }

    public void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.tag == "SnailWall") {
            direction *= -1;
        }
    }
}
