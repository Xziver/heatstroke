using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Image HealthMeter;
    public TMP_Text HealthText;
    public string MainSceneName;

    // Split the statement.
    public int Consciousness = 100;
    public int UnconsciousNumber = 60;
    public int FaintNumber = 20;
    
    // Consciousness cut down.
    public int CutdownSpeed = 1;

    private bool StartAid = true;
    private bool AidSuccess = false;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Consciousness>100) Consciousness = 100;
        if (Consciousness == 0)
        {
            Debug.Log("Fail!");
            EndGame();
        }
        HealthMeter.fillAmount = (float)Consciousness / 100;
        HealthText.text = "Health: " + Consciousness.ToString() + "/100";
        if (StartAid)
        {
            StartCoroutine(ConsciousnessCutdown());
            StartAid = false;
        }
    }
    
    IEnumerator ConsciousnessCutdown()
    {
        while (Consciousness > 0)
        {
            Consciousness -= CutdownSpeed;
            yield return new WaitForSeconds(1);
        }
    }
    
    public void EndGame()
    {
#if UNITY_EDITOR
        // 如果在 Unity 编辑器中运行，仅在播放模式下停止游戏
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在项目中，跳转回原来的场景
        Jumpback();
#endif
    }

    private void Jumpback()
    {
        // 可能需要增加数据恢复的代码
        SceneManager.LoadScene(MainSceneName);
    }
}
