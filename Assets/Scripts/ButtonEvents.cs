using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonEvents : MonoBehaviour
{
    public StateMachine PlayerStateMachine;
    public TMP_Text playerStateText;
    
    void Start()
    {
        PlayerStateMachine.playerState = (int)StateMachine.PlayerState.empty;
        playerStateText.text = "empty";
    }
    void Update()
    {
        
    }

    public void ChangeWater()
    {
       PlayerStateMachine.playerState = (int)StateMachine.PlayerState.water;
       playerStateText.text = "water";
    }
    
    public void ChangeIce()
    {
        PlayerStateMachine.playerState = (int)StateMachine.PlayerState.ice;
        playerStateText.text = "ice";
    }
    
    public void ChangeSaltWater()
    {
        PlayerStateMachine.playerState = (int)StateMachine.PlayerState.salt_water;
        playerStateText.text = "salt_water";
    }

    public void Call120()
    {
        PlayerStateMachine.playerState = (int)StateMachine.PlayerState.call120;
        playerStateText.text = "call120";
    }
    
    public void CPR()
    {
        PlayerStateMachine.playerState = (int)StateMachine.PlayerState.CPR;
        playerStateText.text = "CPR";
    }
}
