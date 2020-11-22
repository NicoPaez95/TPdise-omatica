using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class DemoManager : MonoBehaviour
{
    public int CoinsCount;
    public Text txtcoins;

    public int LIVES;
    public Text TxtLives;
    public Text txtlose;
    public mov_player player;
    public Button resstar;
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

    private void Update()
    {
        if (LIVES<=0)
        {
            Time.timeScale = 0f;
            txtlose.gameObject.SetActive(true);
            resstar.gameObject.SetActive(true);
        }
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

    public void restarscene()
    {
        LIVES = 7;
        Time.timeScale = 1f;
        SceneManager.LoadScene("nivel1");
       

    }

}
