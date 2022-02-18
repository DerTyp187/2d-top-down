using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public enum PartOfDay
    {
        MORNING,
        AFTERNOON,
        EVENING,
        NIGHT
    }

    public PartOfDay partOfDay;

    [SerializeField]
    float intervalTime = 1.0f; // 1.0f -> 1 real second is 1 ingame minute

    [SerializeField]
    int minutesPerInterval = 1;    

    DateTime dateTime = new DateTime(1, 1, 1, 23, 0, 0);

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
        CheckPartsOfDay();
        Debug.Log(GetTime());
    }

    void CheckPartsOfDay()
    {
        Debug.Log(dateTime.Hour);

        if (dateTime.Hour >= 22)
            partOfDay = PartOfDay.NIGHT;
        else if(dateTime.Hour < 6)
            partOfDay = PartOfDay.NIGHT;
        else if (dateTime.Hour >= 6 && dateTime.Hour < 12)
            partOfDay = PartOfDay.MORNING;
        else if (dateTime.Hour >= 12 && dateTime.Hour < 17)
            partOfDay = PartOfDay.AFTERNOON;
        else if (dateTime.Hour >= 17 && dateTime.Hour < 22)
            partOfDay = PartOfDay.EVENING;
    }

    // For Plant growth maybe add a List<GameObject/Script> where those plants can register themselves and every "TimeUp()" they get checked by the TimeManager
}
