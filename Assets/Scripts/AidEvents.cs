using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class AidEvents : MonoBehaviour
{
    public HealthController HealthController;
    public StateMachine PlayerStateMachine;
    public TMP_Text currStateText;
    
    // CPR variables
    private int step = 1;
    public bool doCPR= false;
    public Button CPR_Push,CPR_OpenMouth,CPR_Blow;
    public int PushTime = 0;
    private int CPRTimer;
    
    public enum AidTargets
    {
        empty = 0,
        cool_down,
        supply_water,
        supply_salt_water,
        call_120,
        CPR
    }
    public List<AidTargets> consciousState = new List<AidTargets>(4);
    public List<AidTargets> unconsciousState = new List<AidTargets>(3);
    public List<AidTargets> faintState = new List<AidTargets>(3);
    public List<AidTargets> currState = new List<AidTargets>();
    
    public int currTarget = (int)AidTargets.empty;
    public int currTargetIndex = 0;
    void Start()
    {
        currState= consciousState;
        currStateText.text = "Conscious";
        
        CPR_Push.gameObject.SetActive(false);
        CPR_OpenMouth.gameObject.SetActive(false);
        CPR_Blow.gameObject.SetActive(false);
    }
    
    void Update()
    {
        // Chang the target list according to the state
        if (HealthController.Consciousness > HealthController.FaintNumber&&
            HealthController.Consciousness <= HealthController.UnconsciousNumber && currState == consciousState)
        {
            currState = unconsciousState;
            currStateText.text = "Unconscious";
            currTargetIndex = 0;
        }
        else if (HealthController.Consciousness >= 0 &&
                 HealthController.Consciousness <= HealthController.FaintNumber && currState == unconsciousState)
        {
            currState = faintState;
            currStateText.text = "Faint";
            currTargetIndex = 0;
        }
        // Success
        if (currTargetIndex >= currState.Count)
        {
            HealthController.CutdownSpeed = 0;
            Debug.Log("Success!");
            currTargetIndex = 0;
            HealthController.EndGame();
        }
        // Change the target
        currTarget = (int)currState[currTargetIndex];

        if (doCPR)
        {
            CPR();
        }
    }

    public void CPR()
    {
        HealthController.CutdownSpeed = 0;
        
        // Step 1
        if (step == 1)
        {
            if (CPR_Push.gameObject.activeSelf == false)
            {
                CPR_Push.gameObject.SetActive(true);
            }
            if(CPRTimer == 0)
            {
                StartCoroutine(CPRPush());
            }
            return;
        }
        if (PushTime < 18) HealthController.Consciousness = 0;
        CPR_Push.gameObject.SetActive(false);
        
        // Step 2
        if (step == 2)
        {
            if (CPR_OpenMouth.gameObject.activeSelf == false)
            {
                CPR_OpenMouth.gameObject.SetActive(true);
            }
            return;
        }
        CPR_OpenMouth.gameObject.SetActive(false);
        
        // Step 3
        if (step == 3)
        {
            if (CPR_Blow.gameObject.activeSelf == false)
            {
                CPR_Blow.gameObject.SetActive(true);
            }
            return;
        }
        CPR_Blow.gameObject.SetActive(false);

        if (step == 4)
        {
            currTargetIndex++;
        }
    }
    
    IEnumerator CPRPush()
    {
        while (PushTime < 18 && CPRTimer<30)
        {
            CPRTimer++;
            yield return new WaitForSeconds(1);
        }
        step = 2;
    }

    public void ButtonCount()
    {
        PushTime++;
    }

    public void nextStep()
    {
        step++;
    }

}
