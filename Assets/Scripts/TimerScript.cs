using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimerScript : MonoBehaviour 
{
	public Text timerText;
	private int timer;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        TimeSpan time = TimeSpan.FromSeconds(Time.timeSinceLevelLoad);
        timerText.text = string.Format("{0:D2}:{1:D2}", time.TotalMinutes, time.Seconds);
    }
}
