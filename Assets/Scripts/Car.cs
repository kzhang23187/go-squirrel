using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour {
    public float speed = -4f;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, speed);

	}
	
	// Update is called once per frame
	void Update () {
        if (GameControl.instance.gameOver) {
            rb2d.velocity = Vector2.zero;
        }
		
	}
}
