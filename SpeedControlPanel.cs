using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedControlPanel :MonoBehaviour
{
    //public static int timespeed { get; set; } = 1;

    //private static void DoubleSpeed()
    //{
    //    timespeed *= 2;
    //}

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void ResumeOrPlay()
    {
        Time.timeScale = 1;
    }

    public void FastFoward()
    {
        if(Time.timeScale<=3)//最大快進速度是三
            Time.timeScale += 1;
    }

   
}
