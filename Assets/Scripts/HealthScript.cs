using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public float health;
    public Text healthText;

	// Use this for initialization
	void Start () {
        health = 5;
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = "HP: " + health;
        if (health <= 0) {
            Debug.Log ("You Lose!");
        }
	}
}
