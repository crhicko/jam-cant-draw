using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{

    Rigidbody2D rb;
    private bool isMovePressed = false;
    public float speed = 25.0f;

    Vector2 moveDir;
    Vector2 startMousePosition;
    Vector2 endMousePosition;
    Vector2 direction;
    bool isBraking = false;

    PlayerInput playerInput;


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
        Debug.DrawLine(startMousePosition, endMousePosition, Color.white, 10f);

        if(isMovePressed) {
            // rb.AddForce(moveDir);
            rb.MovePosition((Vector2)transform.position + (moveDir * speed * Time.deltaTime));
        }

        if(isBraking) {
            rb.velocity *= new Vector2(0.97f, 0.97f);
        }
    }

    public void OnMovement(InputAction.CallbackContext context) {
        moveDir = context.ReadValue<Vector2>();

        if(context.phase == InputActionPhase.Started)
            isMovePressed = true;
        else if(context.phase == InputActionPhase.Canceled)
            isMovePressed = false;
    }

    public void OnDrag(InputAction.CallbackContext context) {

        Debug.Log("In On Drag");
        if(context.phase == InputActionPhase.Started) {
            startMousePosition = Mouse.current.position.ReadValue();

            // Debug.Log(startMousePosition);
        }
        else if(context.phase == InputActionPhase.Canceled) {
            endMousePosition = Mouse.current.position.ReadValue();
            // Debug.Log(endMousePosition);
            direction.x = endMousePosition.x - startMousePosition.x;
            direction.y = endMousePosition.y - startMousePosition.y;
            Debug.Log(direction);
            rb.velocity = Vector3.zero;
            rb.AddForce(direction);
            // rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        }
    }

    public void OnBrake(InputAction.CallbackContext context) {

        if(context.phase == InputActionPhase.Started)
            isBraking = true;
        else if(context.phase == InputActionPhase.Canceled)
            isBraking = false;
    }

}
