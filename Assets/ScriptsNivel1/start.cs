
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start : MonoBehaviour
{

    public GameObject Paneloptions;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startgame()
    {

        SceneManager.LoadScene("nivel1");


    }

    public void Quiitgame()
    {

        Application.Quit();

    }

    public void panelenter()
    {
        Paneloptions.SetActive(true);
    }

   public void PanelBack()
    {

        Paneloptions.SetActive(false);


    }

}