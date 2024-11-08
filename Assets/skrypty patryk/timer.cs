using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Slider Slider;
    public float sliderTimer;
    public bool stopTimer=false;
    // Start is called before the first frame update
    void Start()
    {
        Slider.maxValue= sliderTimer;
        Slider.value = sliderTimer;
        StartTimer();
    }
    public void StartTimer()
    {
        StartCoroutine(StartTheTimerTicker());

    }
    IEnumerator StartTheTimerTicker()
    {
        while (stopTimer == false)
        {

            sliderTimer -= Time.deltaTime;
            yield return new WaitForSeconds(0.001f);

            if (sliderTimer <= 0)
            {
             stopTimer = true;
            }
            if (stopTimer == false)
            {
                Slider.value= sliderTimer;
            }
            //tu mogê wpierdoliæ reset sceny pozdro 600 tylko legia 
        }    
    }



}
