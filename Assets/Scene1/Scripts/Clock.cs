using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {
	public GameObject minuteHand;
	public GameObject hourHand;


	void FixedUpdate () {
		DateTime currentTime = DateTime.Now;

		float hour = (float)currentTime.Hour;
		float minute = (float)currentTime.Minute;

        if (hour > 12)
        {
            hour -= 12;
        }

        float minuteAngle = minute / 60 * 360;
		float hourAngle = (hour / 12 * 360) + (minute / 720) * 360;

		hourHand.transform.localRotation = Quaternion.Euler (-hourAngle, 0, 0);
		minuteHand.transform.localRotation = Quaternion.Euler (-minuteAngle, 0, 0);
        
	}


}
