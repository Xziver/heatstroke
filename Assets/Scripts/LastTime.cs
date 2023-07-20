using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LastTime : MonoBehaviour
{
    public bool begin = false;
    public int min;
    public int totalMin;
    public float timeLeft = 1f;
    public bool isA = false;
    public bool isB = false;    
    public bool isC = false;
    bool ishot = false;       //时间用了一半就会耗水量上升
    Text needWater;
    void Start()
    {
        needWater= GetComponent<Text>();
        if (isA)
            min = 12;
        if (isB)
            min = 16;
        if (isC)
            min = 24;           //三个工人不同耗水
        totalMin = min;
    }

    void Update()
    {
        if (begin == true)
        {
            needWater.text = min + "min";
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                min -= 1;
                timeLeft = 1f;
            }

            if(min<totalMin/2)
            {
                ishot = true;
                needWater.color = Color.red;
            }
            if (min <= 0)
            {
                begin = false;
                min = 20;
                needWater.text = "";
                SceneManager.LoadScene("NormalAid");    //场景转换

            }

            else if (isA&&Input.GetKeyUp(KeyCode.A) && DrinkWater.water>=0)
            {
                begin = false;
                min = 12;
                totalMin= min;
                needWater.text = "";
                if (ishot)
                    DrinkWater.water -= 400;
                else
                    DrinkWater.water -= 300;
                ishot = false;
            }
            else if (isB && Input.GetKeyUp(KeyCode.B) && DrinkWater.water >= 0)
            {
                begin = false;
                min = 16;
                totalMin = min;
                needWater.text = "";
                if (ishot)
                    DrinkWater.water -= 500;
                else
                    DrinkWater.water -= 450;
                ishot = false;
            }
            else if (isC && Input.GetKeyUp(KeyCode.C) && DrinkWater.water >= 0)
            {
                begin = false;
                min = 24;
                totalMin = min;
                needWater.text = "";
                if (ishot)
                    DrinkWater.water -= 750;
                else
                    DrinkWater.water -= 500;
                ishot = false;
            }
        }
    }
}
