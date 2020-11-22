using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chest : MonoBehaviour
{

    Animator chestAnim;

    public mov_player Movplayer;

    public DemoManager Coinschest;

    public Text coinstxt;
    // Start is called before the first frame update
    void Start()
    {
        chestAnim = GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Movplayer.pickkey == true)
        {
            chestAnim.SetBool("CHESTFULLL", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player" && Movplayer.isattacking == true && Movplayer.pickkey == true))
        {
            chestAnim.SetTrigger("CHESEMPTYY");

            Coinschest.CoinsCount += 30;

            coinstxt.text = "Monedas:" + Coinschest.CoinsCount;
        }
       
    }






}
