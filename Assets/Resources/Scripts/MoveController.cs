using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{

    Rigidbody2D rb;

    private bool isPressedLeft = false;
    private bool isPressedRight = false;
    private bool isPressedUp = false;
    private bool isPressedDown = false;
    private bool isMovePressed = false;

    Vector2 moveDir;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isMovePressed) {
            rb.AddForce(moveDir);
        }
    }

    public void OnMovement(InputAction.CallbackContext context) {
        moveDir = context.ReadValue<Vector2>();

        if(context.phase == InputActionPhase.Started)
            isMovePressed = true;
        else if(context.phase == InputActionPhase.Canceled)
            isMovePressed = false;
    }

}
