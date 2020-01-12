using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour {

    public float speed = 1.1f;

    private Rigidbody2D rb2d;
    private bool isDead = false;
    public Animator anim;
    public int isIdle = 0;
    public Collider2D[] colliders;
    private int currentColliderIndex = 0;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Entry");
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Wait()
    {
        if (!isDead && !Pause.pause)
        {
            anim.SetTrigger("Idle");
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
        }

    }
    public void Dash() {
        if (!isDead && !Pause.pause && isIdle == 0)
        {
            anim.SetTrigger("Walk");
            rb2d.velocity = new Vector2(5f, 0);
        }

    }
    public void Walk() {
        if (!isDead && !Pause.pause) {
            anim.SetTrigger("Walk");
            rb2d.velocity = new Vector2(0, 0);
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
