using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateMovement : MonoBehaviour {

    private Rigidbody2D pirateRB;
    private Animator anim;

    [SerializeField]
    private float speed = 0.5f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        pirateRB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetTrigger("Derping");
            //pirateRenderer.flipX = true;
            pirateRB.position -= new Vector2(speed, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetTrigger("Derping");
            //pirateRenderer.flipX = false;
            pirateRB.position += new Vector2(speed, 0);
        }
        else
        {
            anim.SetTrigger("Stop");
        }
    }
}
