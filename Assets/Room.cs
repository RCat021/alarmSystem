using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSystem;
    [SerializeField] private float _volumeChangeStep = 0.1f;
    [SerializeField] private float _maxVolume = 1f;
    [SerializeField] private float _minVolume = 0f;

    private bool _isAlarmActive;
    private bool _playerExitRoom;

    private void Awake()
    {
        _alarmSystem.volume = _minVolume;
        _alarmSystem.enabled = false;
        _playerExitRoom = false;
    }

    private void Update()
    {
        if (!_isAlarmActive) return;

        if (_playerExitRoom == false)
            AddAlarmVolume();
        else
            DownAlarmVolume();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
            ActivateAlarm();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
            _playerExitRoom = true;
    }

    private void ActivateAlarm()
    {
        _alarmSystem.enabled = true;
        _isAlarmActive = true;
    }

    private void DeactivateAlarm()
    {
        _isAlarmActive = false;
        _alarmSystem.enabled = false;
    }

    private void AddAlarmVolume()
    {
        SetAlarmVolume(_alarmSystem.volume + _volumeChangeStep);
    }

    private void DownAlarmVolume()
    {
        SetAlarmVolume(_alarmSystem.volume - _volumeChangeStep);

        if (_alarmSystem.volume <= _minVolume)
            DeactivateAlarm();
    }

    private void SetAlarmVolume(float volume)
    {
        _alarmSystem.volume = Mathf.Clamp(volume, _minVolume, _maxVolume);
    }
}