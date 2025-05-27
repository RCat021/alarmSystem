using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSystem;
    [SerializeField] private float _speed = 0.1f;
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
        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);

        _activeCoroutine = StartCoroutine(SetValue(volume));
    }

    private IEnumerator SetValue(float endVolume)
    {
        while (Mathf.Approximately(_alarmSystem.volume, endVolume) == false)
        {
            _alarmSystem.volume = Mathf.MoveTowards(_alarmSystem.volume, endVolume, _speed * Time.deltaTime);

            yield return null;
        }
    }
}
