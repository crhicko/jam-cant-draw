using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShotController : MonoBehaviour
{

    public int _ammoCount = 0;

    private GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = Resources.Load("Prefabs/Puck") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddAmmo(int amount) {
        _ammoCount += amount;
    }

    public void Shoot(InputAction.CallbackContext context) {
        if(_ammoCount <= 0)
            return;
        Debug.Log(context.phase);
        if(context.phase == InputActionPhase.Started) {
            Vector3 curPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            curPos.z = 0;

            GameObject puck = Instantiate(projectile, transform.position, Quaternion.identity);
            // puck.GetComponent<Collider2D>().
            // Debug.Log(puck.GetComponent<TeamController>());
            puck.GetComponent<PuckController>().ChangeTeam(Team.Player);
            GameManager.Instance._puckList.Add(puck);
            puck.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position - curPos) * -0.01f);

            _ammoCount--;
        }
    }
}
