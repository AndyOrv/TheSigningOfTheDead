using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public Text timerText;
    
    void Start()
    {
        timerText.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = timeStart.ToString("F2");
    }
    public void addTime(float amount)
    {
        timeStart += amount;
    }
}
