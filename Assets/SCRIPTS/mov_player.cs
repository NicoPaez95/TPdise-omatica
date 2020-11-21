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

    public bool isattacking = false;

    public MonoBehaviour camMono;
    private void Start()
    {
        animator=GetComponent<Animator>();


        rb = GetComponent<Rigidbody2D>();

        camMono = Camera.main.GetComponent<MonoBehaviour>();



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

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("attack");

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

        if (collision.gameObject.tag=="jenny"&& isattacking == false)
        {

            animator.SetTrigger("PlayerDead");

           StartCoroutine(playerdead());
        }

        if (collision.gameObject.tag == "cactus" && isattacking == false)
        {
            animator.SetTrigger("PlayerDead");

            StartCoroutine(playerdead());
        }

    }
        

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f);

        isattacking = false;
    }

    public void dodamage()
    {
        isattacking = true;
    }

    public void ExitDoDamage()
    {
        StartCoroutine(delay());
    }


    IEnumerator playerdead()
    {
        
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);

        camMono.StartCoroutine(returnPlayer());

        this.die.Invoke();

      
    }

    IEnumerator returnPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(true);

        this.gameObject.transform.position = new Vector3(-22, 414, 0);

    }

}
