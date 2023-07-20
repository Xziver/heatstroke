using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DrinkWater : MonoBehaviour
{
    public  GameObject[] workers;
    public float interval = 10.0f;       //每10s随机一个工人需要水
    public static int water = 6000;
    public Text waterText;
    void Start()
    {
        InvokeRepeating("ChooseWorker", interval, interval);
    }

    int ChooseWorker()
    {
        int index = Random.Range(0, workers.Length);
        return index;
    }

    void Update()
    {
        if (Time.time >= interval)
        {
            interval += 10.0f;
            workers[ChooseWorker()].GetComponent<LastTime>().begin = true;
        }
        waterText.text = "Water we have now:"+water + "ml";
    }
}


