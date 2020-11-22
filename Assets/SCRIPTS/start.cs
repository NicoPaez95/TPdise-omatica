using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
	
public class start : MonoBehaviour
{
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
}
