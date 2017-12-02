using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyScript : MonoBehaviour {
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public GameObject bulletPrefab;
    public float bulletSpeed = 0.5f;
    public Vector3 bulletDir = new Vector3 (-1, 0, 0);

    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();
    
    void Start() {
        posOffset = transform.position;
    }

    void Update() {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
        System.Random rnd = new System.Random ();
        if (rnd.Next(0, 100) == 1) {
            GameObject bullet = Instantiate (bulletPrefab, new Vector3(transform.position.x, Camera.main.gameObject.GetComponent<CameraController>().obj.transform.position.y, transform.position.z), transform.rotation);
            bullet.SetActive (true);
            var ebs = bullet.AddComponent<EnemyBulletScript> ();
            ebs.speed = bulletSpeed;
            ebs.direction = bulletDir;
            Destroy (bullet, 30.0f);
        }
    }
}
