using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.name == "BirdGO")
        {
            GameManager.me.GameOver();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.name == "BirdGO")
        {
            GameManager.me.GameOver();
        }
    }


}
