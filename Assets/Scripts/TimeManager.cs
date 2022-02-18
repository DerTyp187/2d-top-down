using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    float intervalTime = 1.0f; // 1.0f -> 1 real second is 1 ingame minute

    [SerializeField]
    int minutesPerInterval = 1;

    DateTime dateTime = new DateTime(1, 1, 1, 0, 0, 0);

    public DateTime GetDateTime() => dateTime;
    public string GetTime() => dateTime.ToString("hh:mm tt");
    public string GetDate() => dateTime.ToString("dd/mm/yyyy");

    void Start()
    {
        InvokeRepeating("TimeUp", intervalTime, intervalTime);    
    }

    void TimeUp()
    {
        dateTime = dateTime.AddMinutes(minutesPerInterval);
    }

    // For Plant growth maybe add a List<GameObject/Script> where those plants can register themselves and every "TimeUp()" they get checked by the TimeManager
}
