using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VelocityLimiter : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log(rb);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
