using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _direction = -1;

    private float maxRemovalPointAlongAxisX = -20f;

    private void Update()
    {
        Move(_direction);

        if(transform.position.x <= maxRemovalPointAlongAxisX)
        {
            Destroy(gameObject);
        }
    }   

    private void Move(int direction)
    {
        transform.Translate(_speed * direction * Time.deltaTime, 0, 0);
    }
}