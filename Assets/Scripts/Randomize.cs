using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Randomize : MonoBehaviour
{
    public int minValue = 70,maxValue = 90;
    public GameObject HealthPoints;
    public GameObject BeginTextImage;
    public TMP_Text BeginText;
    
    private void Awake()
    {
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        // 严重中暑的情况下，意识值为20
        if (currentSceneName == "SeriousAid")
        {
            HealthController healthController= HealthPoints.GetComponent<HealthController>();
            healthController.Consciousness = 21;
        }
        else
        {
            RandomizeConsciousness();
        }
    }

    private void Start()
    {
        Time.timeScale = 0;
        BeginText.text = "Hurry!!! Quickly cool them down. To keep things from getting worse I need to get them in order!!!!!";
    }

    private void Update()
    {
        if (BeginTextImage.activeSelf && Input.anyKeyDown) 
        {
            BeginTextImage.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void RandomizeConsciousness()
    {
        HealthController healthController= HealthPoints.GetComponent<HealthController>();
        healthController.Consciousness = UnityEngine.Random.Range(minValue, maxValue);
    }
}
