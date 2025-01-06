using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    public float elapsedTime = 0;
    public bool isRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        StartCoroutine(UpdateTimer());
    }

    // Update is called once per frame
   
    IEnumerator UpdateTimer()
    {
        while(isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText(elapsedTime);
            yield return null;  
        }
    }

    void UpdateTimerText(float time)
    {
        int minutes=Mathf.FloorToInt(elapsedTime/60);
        int second=Mathf.FloorToInt(elapsedTime%60);

        timerText.text=string.Format("{0:00} : {1:00}",minutes,second);
    }
    public void StopTimer()
    {
        isRunning=false;
    }


}
