using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_player : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rb;

    bool enSuelo = true;
    private void Start()
    {
        animator=GetComponent<Animator>();


        rb = GetComponent<Rigidbody2D>();

        
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            
            rb.AddForce(Vector2.right * 1000f, ForceMode2D.Impulse);

            transform.localScale = new Vector3(1, 1);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * 1000f, ForceMode2D.Impulse);

            transform.localScale = new Vector3(-1, 1);
        }

        float RbVelocity = Mathf.Abs(rb.velocity.x);


        animator.SetFloat("speed", RbVelocity);

        //Debug.Log(RbVelocity);


       

    }


    private void Update()
    {
        if (enSuelo == true && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("tocosuelo");
            enSuelo = false;
            rb.AddForce(Vector2.up * 60000, ForceMode2D.Impulse);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "plataformas")
        {
            enSuelo = true;
            //anim.SetBool("salta", false);    
        }
    }



}
