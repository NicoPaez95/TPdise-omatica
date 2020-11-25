using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus : MonoBehaviour
{
    Animator animCactus;
    public mov_player mov1player;
    private void Start()
    {
        animCactus = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && mov1player.isattacking == true)
        {
            StartCoroutine(waiter());
        }
        if (collision.gameObject.tag == "Player" && mov1player.isattacking == false)
        {
            animCactus.SetBool("angry", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animCactus.SetBool("angry", false);
        }
    }

 

    IEnumerator waiter()
    {
        animCactus.SetTrigger("die");

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }


}
