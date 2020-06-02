using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipperAttachment : MonoBehaviour
{
    public GameObject flipper;
    // Start is called before the first frame update
    void Start()
    {
        if(flipper != null) {
            GameObject obj = Instantiate(flipper, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnInput(InputAction.CallbackContext context) {
        flipper.GetComponent<IActivatable>().Activate();
    }
}
