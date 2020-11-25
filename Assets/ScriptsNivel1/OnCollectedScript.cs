using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnCollectedScript : MonoBehaviour
{
    public UnityEvent OnCollected = new UnityEvent();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("colisiono");
            OnCollected.Invoke();
            Destroy(gameObject);
        }
    }



}
