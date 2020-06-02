    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject puck;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), puck.GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

     void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.gameObject == puck)
         {
             Debug.Log("HIT");
             puck.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
         }
     }

}
