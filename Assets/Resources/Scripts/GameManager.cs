using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject eastGoal;
    public GameObject puck;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(eastGoal.GetComponent<BoxCollider2D>(), puck.GetComponent<CircleCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
