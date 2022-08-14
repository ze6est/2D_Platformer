using UnityEngine;

public class MoverBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private int _direction = -1;

    private void Update()
    {
        Move(_direction);
    }

    private void Move(int direction)
    {
        transform.Translate(_speed * direction * Time.deltaTime, 0, 0);
    }
}
