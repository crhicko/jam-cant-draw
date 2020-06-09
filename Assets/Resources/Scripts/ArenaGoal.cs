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

    private float shieldTimer = 6.0f;
    private bool shielding = false;
    PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shielding)
        {
           
            if(shieldTimer <= 5.0f && shieldTimer >= 4.0f)
            {
                foreach(Transform child in transform)
                {
                    if(child.gameObject.activeInHierarchy)
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }

            shieldTimer -= Time.deltaTime;
            
            if(shieldTimer < 0.0f)
            {
                shielding = false;
                shieldTimer = 6.0f;
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
