using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jenny : MonoBehaviour
{
    // Start is called before the first frame update

    Animator animJenny;

    public mov_player mov1player;

    public DemoManager demoman;

    private Rigidbody2D rbjenny;

    public float speed;

    private void Start()
    {
        animJenny = GetComponent<Animator>();

        rbjenny = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        rbjenny.velocity = new Vector2(speed, rbjenny.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && mov1player.isattacking == true)
        {
            this.GetComponent<Collider2D>().isTrigger = false;
            animJenny.SetBool("walk", true);

        }
        if (collision.gameObject.tag == "Player" && mov1player.isattacking == false)
        {
            animJenny.SetBool("walk", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player" && mov1player.isattacking == true))
        {
            StartCoroutine(waiter());
        }

      

    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
         {
                animJenny.SetBool("walk", true);
         }

        if (collision.gameObject.tag == "plataformas")
        {
                speed *= -1;

                this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
         }

    }


    IEnumerator waiter()
    {
        animJenny.SetTrigger("die");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);


    }

    
 
 }

