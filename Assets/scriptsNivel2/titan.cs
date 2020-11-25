using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titan : MonoBehaviour
{

    // Start is called before the first frame update

    Animator titananim;
    Rigidbody2D titanrb;
    public mov_player mov1player;
    public float speed;

    void Start()
    {
        titananim = GetComponent<Animator>();
        titanrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        titanrb.velocity = new Vector2(speed, titanrb.velocity.y);
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

        if (collision.gameObject.tag == "plataformas")
        {
            speed *= -1;

            this.transform.localScale = new Vector2(this.transform.localScale.x * -1, this.transform.localScale.y);
        }

    }

    IEnumerator waiter()
    {
        titananim.SetTrigger("die");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);


    }
}
