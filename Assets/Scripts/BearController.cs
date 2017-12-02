using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour {

    public float moveSpeed = 1;
    public float jumpThrust = 1;

    public float maxMoveSpeed = 0;
    public float speed = 0;
    public float slowDownSpeed = 0.9f;

    Rigidbody rb;
    

    HealthScript health;
    
	void Start () {
        health = GetComponent<HealthScript> ();
        rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
        if (Input.GetKey (KeyCode.D)) {
            Vector3 force = transform.right * (maxMoveSpeed - speed);
            rb.AddForce (force);
        }
        if (Input.GetKey (KeyCode.A)) {
            Vector3 force = transform.right * (-maxMoveSpeed + Mathf.Abs(speed));
            rb.AddForce (force);
        }
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
            rb.velocity = new Vector3 (rb.velocity.x * slowDownSpeed, rb.velocity.y, rb.velocity.z * slowDownSpeed);
        }
        if (Input.GetKeyDown (KeyCode.Space) && isGrounded()) {
            Jump ();
        }
        transform.rotation = new Quaternion();
        transform.position = new Vector3 (transform.position.x, transform.position.y, 0);
        speed = rb.velocity.x;
        
    }

    public void Jump() {
        GetComponent<Rigidbody> ().AddForce (transform.up * jumpThrust, ForceMode.Impulse);
    }

    bool isGrounded() {
        Ray ray = new Ray (transform.position, Vector3.down);
        RaycastHit hit;
        return Physics.Raycast (ray, out hit, 1.01f);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.name.Contains("Bullet")) {
            health.health--;
        }
        if (collision.collider.gameObject.tag == "Enemy") {
            Jump ();
        }
    }
}
