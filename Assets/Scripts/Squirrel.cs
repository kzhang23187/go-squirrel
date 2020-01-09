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

        if (isDead == false) {
            //for click to  pause: Input.GetMouseButton(0) 
            if (Input.GetKey(KeyCode.D) && !Pause.pause && isIdle == 0) {
                anim.SetTrigger("Walk");
                rb2d.velocity = new Vector2(5f, 0);
            }
            else if (Input.GetKey(KeyCode.A) && !Pause.pause) {
                anim.SetTrigger("Idle");
                rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
            } else {
                anim.SetTrigger("Walk");
                rb2d.velocity = new Vector2(0, 0);
            }

            //if (Input.GetKey(KeyCode.W) && !Pause.pause)
            //{
            //    isIdle = 1;
            //}
            //if (Input.GetKeyUp(KeyCode.W) && !Pause.pause)
            //{
            //    anim.SetTrigger("Walk");
            //    rb2d.velocity = new Vector2(speed, 0);
            //    isIdle = 0;
            //    return;
            //}
            //if (Input.GetKeyDown(KeyCode.W) && !Pause.pause)
            //{

            //    anim.SetTrigger("Idle");
            //    rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
            //    isIdle = 1;
            //    return;

            //}

            //if (isIdle != 1 && transform.position.x > 0)
            //{
            //    rb2d.velocity = new Vector2(0, 0);
            //}

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
