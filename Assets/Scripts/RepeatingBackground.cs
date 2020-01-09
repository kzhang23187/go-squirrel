using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D groundCollider;
    private float groundLength;
    public float start;

	// Use this for initialization
	void Start () {
        groundCollider = GetComponent<BoxCollider2D>();
        groundLength = groundCollider.size.x;
        start = transform.position.x - groundLength / 2;
	}
	
	// Update is called once per frame
	void Update () {
        start = transform.position.x - groundLength / 2;
        if (transform.position.x < -groundLength) 
        {
            RepositionBackground();
        }
		
	}
    private void RepositionBackground() {
        Vector2 groundOffset = new Vector2(groundLength * 4f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}