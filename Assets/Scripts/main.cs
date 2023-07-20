using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    public int inGameTime_min = 0;
    public int inGameTime_hour = 0;
    static int dateTime = 0;
    public int min2gamehour = 2;
    public int dayStartHour = 11;
    public int dayEndHour = 16;
    public int tempreture = 35;
    public bool isPause = true;

    #region Event
    public List<GameEvent> workerEvents;
    public GameEvent gameStartEvent;
    #endregion
    
    public Text timeText;
    private double dtime = 0;

    void Start()
    {
        isPause =true;
        inGameTime_min = 0;
        dtime = 0;
        gameStartEvent.TriggerEvent();
    }
    public void GameStart()
    {
        Debug.Log("GameStart");
    }
    string convertDateTime(int time_min){
        string outstr = "";
        int days = 0;
        int hours = dayStartHour;
        int mins = time_min;
        while(mins > 60)
        {
            mins -= 60;
            hours += 1;
            if(hours > dayEndHour)
            {
                hours = dayStartHour;
                days += 1;
            }
        }
        inGameTime_hour = hours;
        string minstring = mins > 9?mins.ToString():"0" + mins.ToString();
        outstr = days.ToString() + "d" + hours.ToString() + ":" + minstring;
        return outstr;
    }
    static int getTime()
    {
        return dateTime;
    }
    void Update()
    {
        if(dtime > min2gamehour && !isPause)
        {
            // update
            main.dateTime = inGameTime_min;
            inGameTime_min += 1;
            dtime = 0;
            timeText.text = convertDateTime(inGameTime_min);

            // if(inGameTime_min % 60 == 0)
            // {

            // }
        }
        else
        {
            dtime += Time.deltaTime;
        }
    }

}
