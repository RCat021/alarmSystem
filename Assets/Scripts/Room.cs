using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    public void StartAlarm() =>
        _alarm.StartAlarm();

    public void StopAlarm() =>
        _alarm.StopAlarm();

}