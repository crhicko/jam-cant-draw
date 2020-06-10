using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HorseshoeState {
    Moving,
    Charging,
    WaitingToShoot,
    Firing
}

public class HorseshoeShotController : MonoBehaviour
{

    public GameObject goal;
    Animator animator;
    Rigidbody2D rb;

    private Vector3 faceDirection;

    private HorseshoeState horseshoeState;

    public GameObject projectile;

    private Vector3 _destination;


    bool _waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        horseshoeState = HorseshoeState.Moving;
    }

    // Update is called once per frame
    void Update()
    {


        if(rb.velocity == Vector2.zero){
            // StartCoroutine(ChargeUp());
        }

        switch (horseshoeState)
        {
            case HorseshoeState.Moving:
                rb.freezeRotation = false;
                if(NeedsDestination()){
                    _destination = GenerateNewDestination();
                   // Debug.Log(_destination);
                }

                //face the goal
                faceDirection = gameObject.transform.position - goal.transform.position;
                float angle = Mathf.Atan2(faceDirection.y, faceDirection.x) * Mathf.Rad2Deg;
                rb.rotation = angle + -90f;

                //MoveToDestination
                // transform.Translate((_destination - transform.position) * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position,_destination,0.04f);

                if(transform.position == _destination) {
                    horseshoeState = HorseshoeState.Charging;
                    //Debug.Log("go to charging");
                }

                break;
            case HorseshoeState.Charging:
               // Debug.Log("begingernerating");
                animator.SetTrigger("BeginGenerating");
                if(_destination != Vector3.zero) {
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }

                _destination = Vector3.zero;    //I dont like this, need to make cleaner
                break;
            case HorseshoeState.WaitingToShoot:
                animator.ResetTrigger("BeginGenerating");
                animator.SetTrigger("ReadyToShoot");
                rb.freezeRotation = true;
                if(!_waiting)   //this is needed or else we will continuously invoke this due to update, want to find a better way to do ai that doesnt involve this
                    StartCoroutine(WaitToShoot());
                // horseshoeState = HorseshoeState.Firing;
                break;
            case HorseshoeState.Firing:
                GameObject puck = Instantiate(projectile, transform.GetChild(0).position, Quaternion.identity);
                GameManager.Instance._puckList.Add(puck);
                puck.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position - goal.transform.position) * 0.01f);
                //Debug.Log("howmuch is this firing");
                animator.ResetTrigger("ReadyToShoot");
                animator.SetTrigger("ReturnToIdle");
                horseshoeState = HorseshoeState.Moving;
                break;
            default:
                break;
        }
    }

    private bool NeedsDestination(){
        if(_destination == Vector3.zero)
            return true;

        return false;
    }

    private Vector3 GenerateNewDestination() {
        return new Vector3(Random.Range(-4f, 4f),Random.Range(2f, 3f),0);
    }

    public void DoneCharging() {
        horseshoeState = HorseshoeState.WaitingToShoot;
    }

    private IEnumerator WaitToShoot() {
        _waiting = true;
        yield return new WaitForSeconds(1f);
        _waiting = false;
        horseshoeState = HorseshoeState.Firing;
    }
}
