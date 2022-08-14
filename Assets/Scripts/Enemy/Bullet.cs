using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        if(transform.position.x <= maxRemovalPoint.x)
        {
            Destroy(gameObject);
        }
    }
}