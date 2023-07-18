using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public AidEvents aidEvents;
    public StateMachine PlayerStateMachine;
    public HealthController healthController;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (PlayerStateMachine.playerState == aidEvents.currTarget)
        {
            if (PlayerStateMachine.playerState == (int)StateMachine.PlayerState.CPR)
            { 
                aidEvents.doCPR = true;
            }
            else
            {
                healthController.Consciousness += 10;
                aidEvents.currTargetIndex++;
            }
            
        }
        else
        {
            if (aidEvents.doCPR == false)
            {
                healthController.Consciousness -= 10;
            }
        }
    }
}
