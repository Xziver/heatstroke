using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum PlayerState
    {
        empty = 0,
        ice,
        water,
        salt_water,
        call120,
        CPR
    };
    
    public int playerState = (int)PlayerState.empty;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
