using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

    public float moveSpeed = 1;
    public float flyThrust = 1;

    HealthScript health;

    void Start() {
        health = GetComponent<HealthScript> ();
    }

    void Update() {
        if (Input.GetKey (KeyCode.D)) {
            transform.Translate (transform.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey (KeyCode.A)) {
            transform.Translate (-transform.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey (KeyCode.Space)) {
            GetComponent<Rigidbody> ().AddForce (transform.up * flyThrust, ForceMode.Impulse);
        }
        transform.rotation = new Quaternion ();
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
    }

    bool isGrounded() {
        Ray ray = new Ray (transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast (ray, out hit, 1.01f)) {
            Debug.Log (hit.transform.name);
            return true;
        }
        return false;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.name.Contains ("Bullet")) {
            health.health--;
        }
    }
}
