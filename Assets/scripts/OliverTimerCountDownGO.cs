using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class OliverTimerCountDownGO : MonoBehaviour
{
    public int countDownStartValue = 20;
    public Text timerUI;
    
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        if(countDownStartValue > 0)
        {
            timerUI.text = "Time Left : " + countDownStartValue;
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            timerUI.text = "NoPay!!! Press R to to try again";
            Application.LoadLevel(4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(4);
        }  
    }
}
