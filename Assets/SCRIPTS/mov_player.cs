using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class mov_player : MonoBehaviour
{
    Animator animator;

    Rigidbody2D rb;

    bool enSuelo = true;

    public UnityEvent die = new UnityEvent();
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


        Vector2 velocidad = rb.velocity;
        velocidad.x = Mathf.Clamp(velocidad.x, -320, 320);

        velocidad.y = Mathf.Clamp(velocidad.y, -1000, 1000);

        rb.velocity = velocidad;

        




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

        //vidas//

        if (collision.gameObject.tag== "limiteinferior")
        {
            this.gameObject.transform.position = new Vector3(-22, 414, 0);

            Debug.Log("muere");
            die.Invoke();
        }
        
    }
    
}
