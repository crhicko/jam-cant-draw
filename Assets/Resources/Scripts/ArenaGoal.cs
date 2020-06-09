using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArenaGoal : MonoBehaviour
{

    public GameObject northShield;
    public GameObject eastShield;
    public GameObject westShield;
    public GameObject southShield;

    public float shieldTimer = 10.0f;

    public float SHIELD_TIMER_MAX = 10.0f;
    private bool shielding = false;
    PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        shieldTimer = SHIELD_TIMER_MAX;
    }

    // Update is called once per frame
    void Update()
    {
        if(shielding)
        {
           if(shieldTimer == SHIELD_TIMER_MAX)
           {
               shieldTimer = 0;
           }
            if(shieldTimer <= 2.0f && shieldTimer >= 1.0f)
            {
                foreach(Transform child in transform)
                {
                    if(child.gameObject.activeInHierarchy)
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }

            shieldTimer += Time.deltaTime;
            
            if(shieldTimer >= SHIELD_TIMER_MAX)
            {
                shielding = false;
                shieldTimer = SHIELD_TIMER_MAX;
            }
        }
    }

    public void OnNorthShield()
    {
        if(!shielding)
        {
            northShield.SetActive(true);
            shielding = true;
        }

    }
      public void OnEastShield()
    {
         if(!shielding)
        {
            eastShield.SetActive(true);
            shielding = true;
        }
    }
      public void OnWestShield()
    {
         if(!shielding)
        {
            westShield.SetActive(true);
            shielding = true;
        }
    }
      public void OnSouthShield()
    {
         if(!shielding)
        {
            southShield.SetActive(true);
            shielding = true;
        }
    }
}
