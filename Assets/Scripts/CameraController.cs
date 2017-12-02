using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject obj;
    Vector3 offset;
    public float speed = 1.0F;
    
    void Start() {
        offset = transform.position - obj.transform.position;
    }
    
    void Update() {
        //transform.position = obj.transform.position + offset;
        transform.position = Vector3.Lerp (transform.position, obj.transform.position + offset, speed);
    }
}
