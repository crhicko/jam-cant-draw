using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperHitCounter : MonoBehaviour
{
    [SerializeField]
    private int numHits = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("Collision detected on: " + gameObject);
        if(col.collider.name == "Puck")
            numHits++;
    }
}
