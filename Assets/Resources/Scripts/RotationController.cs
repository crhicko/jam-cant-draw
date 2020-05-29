using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationController : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    private float angle;

    private bool isPressedLeft = false;
    private bool isPressedRight = false;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.MoveRotation(angle);
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressedLeft) {
            rb.MoveRotation(angle += 1);
        }
        if(isPressedRight) {
            rb.MoveRotation(angle -= 1);
        }
    }

    public void RotateLeft(InputAction.CallbackContext context) {
        if(context.phase == InputActionPhase.Started)
            isPressedLeft = true;
        else if(context.phase == InputActionPhase.Canceled)
            isPressedLeft = false;
    }

    public void RotateRight(InputAction.CallbackContext context) {
        if(context.phase == InputActionPhase.Started)
            isPressedRight = true;
        else if(context.phase == InputActionPhase.Canceled)
            isPressedRight = false;
    }
}
