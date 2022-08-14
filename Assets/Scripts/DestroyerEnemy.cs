using UnityEngine;
using UnityEngine.Events;

public class DestroyerEnemy : MonoBehaviour
{
    private CoinSpawner _coinSpawner;    

    public event UnityAction Destroyed;    

    private void Awake()
    {        
        _coinSpawner = GetComponentInParent<CoinSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            Destroyed.Invoke();            
            Vector2 enemyPosition = new Vector2(transform.position.x, transform.position.y);
            _coinSpawner.CreateCoin(enemyPosition);            
        }
    }
}