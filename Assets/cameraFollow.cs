using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector2 mincampos,maxcampos;
    public float smoothtime;

    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothtime);
        float posy = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothtime);

        transform.position = new Vector3(
            Mathf.Clamp(posx,mincampos.x,maxcampos.x),
            Mathf.Clamp(posy, mincampos.y, maxcampos.y), 
            transform.position.z);
        
    }
}
