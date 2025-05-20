using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        float newX = Mathf.MoveTowards(transform.position.x, _target.position.x, _speed * Time.deltaTime);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
