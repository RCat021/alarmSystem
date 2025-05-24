using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSystem;
    [SerializeField] private float _stepVolume = 0.1f;
    [SerializeField] private float _stepTime = 0.1f;

    private float _maxVolume = 1f;
    private float _minVolume = 0f;

    private Coroutine _activeCoroutine;

    private void Awake()
    {
        _alarmSystem.volume = _minVolume;
    }

    public void StartAlarm()
    {
        SetNewAlarm(_maxVolume);
    }

    public void StopAlarm()
    {
        SetNewAlarm(_minVolume);
    }

    private void SetNewAlarm(float volume)
    {
        if(_activeCoroutine != null) 
            StopCoroutine( _activeCoroutine);

        _activeCoroutine = StartCoroutine(SetValue(volume));
    }

    private IEnumerator SetValue(float endVolume)
    {
        float startVolume = _alarmSystem.volume;
        float direction = Mathf.Sign(endVolume - startVolume); 
        float nextVolume = startVolume;

        var time = new WaitForSeconds(_stepTime);

        while (direction > 0 ? nextVolume < endVolume : nextVolume > endVolume)
        {
            nextVolume += _stepVolume * direction; 
            _alarmSystem.volume = Mathf.Clamp(nextVolume, _minVolume, _maxVolume);
            yield return time;
        }

        _alarmSystem.volume = Mathf.Clamp(endVolume, _minVolume, _maxVolume);
        _activeCoroutine = null;
    }
}
