using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour {

    public float speed = 1f;

    private Rigidbody2D rb2d;
    private bool isDead = false;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        if (isDead == false) {

            if (Input.GetMouseButtonUp(0))
            {
                anim.SetTrigger("Walk");
                rb2d.velocity = new Vector2(speed, 0);
            }
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Idle");
                rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
                return;

            }

        }

		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "road") {
            GameControl.instance.SquirrelScored();
        }
        else {
            isDead = true;
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger("Die");
            GameControl.instance.SquirrelDied();
        }

    }
}
