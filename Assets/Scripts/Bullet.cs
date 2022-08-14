using UnityEngine;

public class Bullet : MonoBehaviour
{    
    [SerializeField] private float _speed;
    [SerializeField] private int _direction = -1;

    private Vector2 maxRemovalPoint = new Vector2(-20, 0);

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            Destroy(gameObject);
        }        
    }

    private void Update()
    {
        Move(_direction);

        if(transform.position.x <= maxRemovalPoint.x)
        {
            Destroy(gameObject);
        }
    }   

    private void Move(int direction)
    {
        transform.Translate(_speed * direction * Time.deltaTime, 0, 0);
    }
}