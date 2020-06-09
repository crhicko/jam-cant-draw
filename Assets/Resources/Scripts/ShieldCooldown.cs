using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldCooldown : MonoBehaviour
{
    public GameObject goal;
    private ArenaGoal goalScript;

    
    private float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        goalScript = goal.GetComponent<ArenaGoal>();
    }

    // Update is called once per frame
    void Update()
    {  
        gameObject.GetComponent<Slider>().value = goalScript.shieldTimer/goalScript.SHIELD_TIMER_MAX;
        
    }
}
