using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class DemoManager : MonoBehaviour
{
    public int CoinsCount;
    public Text txtcoins;

    public int LIVES;
    public Text TxtLives;
    public mov_player player;
    // Start is called before the first frame update
    void Start()
    {
        //monedas//
        OnCollectedScript[] coinss = FindObjectsOfType<OnCollectedScript>();
        foreach (OnCollectedScript coin in coinss)
        { 
            coin.OnCollected.AddListener(Oncoinscollect);
        }
        //vidas
        LIVES = 7;

        player.die.AddListener(DIE);
    }

    private void Oncoinscollect()
    {
        CoinsCount++;

        txtcoins.text = "Monedas:" + CoinsCount;
    
    }

    private void DIE()
    {
        LIVES=LIVES-1;
        TxtLives.text = "Vidas:" + LIVES;
    }
}
