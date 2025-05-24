using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private Room _room;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
            _room.StartAlarm();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _))
            _room.StopAlarm();
    }
}
