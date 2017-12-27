using System;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public Transform hoursTransform, minutesTransform, secondsTransform;
    const float degreesPerHour = 30f; const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;

    // Use this for initialization
    void Start()
    {

        //I got nothing
    }

    // Update is called once per frame
    void Update()
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * degreesPerHour + time.Minute / 60f * 30f, 0f);
        minutesTransform.localRotation = Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
    }
}
