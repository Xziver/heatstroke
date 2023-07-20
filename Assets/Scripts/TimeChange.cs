using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeChange : MonoBehaviour
{
    [SerializeField] int hour;
    [SerializeField] int minute;
    public Text temp;
    private float timeLeft = 60f;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        hour = 11;
        minute = 0;
    }

    void Update() //计时工具
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            DrinkWater.water += 2000;
            timeLeft = 60f;
        }
        hour = 11 + (int)Time.timeSinceLevelLoad/ 60;
        minute = ((int)Time.timeSinceLevelLoad% 60);
        if (minute <10)
            this.gameObject.GetComponent<Text>().text = hour+":0"+minute;
        else
            this.gameObject.GetComponent<Text>().text = hour + ":" + minute;
        if (hour == 11)
            temp.text =35+"℃";
        if (hour == 12)
            temp.text = 38 + "℃";
        if (hour == 13)
            temp.text = 40 + "℃";
        if (hour == 14)
            temp.text = 39 + "℃";
        if (hour == 15)
            temp.text = 37 + "℃";

        //if(hour == 16)
        //{
        //    游戏结束;
        //}
    }
}
