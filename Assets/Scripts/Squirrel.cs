using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour {

    public float speed = 1.1f;

    private Rigidbody2D rb2d;
    private bool isDead = false;
    private Animator anim;
    public Collider2D[] colliders;
    private int currentColliderIndex = 0;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        if (isDead == false) {
            int count = 0;

            if (Input.GetMouseButton(0))
            {
                count = 1;
            }
            if (Input.GetMouseButtonUp(0))
            {
                anim.SetTrigger("Walk");
                rb2d.velocity = new Vector2(speed, 0);
                count = 0;
            }
            if (Input.GetMouseButtonDown(0))
            {

                anim.SetTrigger("Idle");
                rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
                count = 1;
                return;

            }

            if (count != 1 && transform.position.x > 0)
            {
                rb2d.velocity = new Vector2(0, 0);
            }

        }

		
	}
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "road") {
            GameControl.instance.SquirrelScored();
        }
        else if (collision.gameObject.tag == "wall" || collision.gameObject.tag =="car") {
            isDead = true;
            rb2d.velocity = Vector2.zero;
            anim.SetTrigger("Die");
            GameControl.instance.SquirrelDied();
        }

    }
}
