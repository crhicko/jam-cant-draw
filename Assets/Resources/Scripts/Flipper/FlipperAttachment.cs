using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperAttachment : MonoBehaviour
{
    [SerializeField]
    private GameObject flipper;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInput(InputAction.CallbackContext context) {
        flipper.GetComponent<IActivatable>().Activate();
    }
}
