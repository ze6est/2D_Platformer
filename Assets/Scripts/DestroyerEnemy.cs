using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DestroyerEnemy : MonoBehaviour
{
    [SerializeField] CoinSpawner _coinSpawner;

    private Enemy _enemy;
    private float _delayBeforeDeath = 0.001f;
    private UnityEvent _destroyed = new UnityEvent();

    public event UnityAction Destroyed
    {
        add => _destroyed.AddListener(value);
        remove => _destroyed.RemoveListener(value);
    }

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        _coinSpawner = GetComponentInParent<CoinSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            _destroyed.Invoke();
            Collider2D collider2D = _enemy.GetComponent<Collider2D>();
            collider2D.enabled = false;
            Vector2 enemyPosition = new Vector2(transform.position.x, transform.position.y);
            _coinSpawner.CreateCoin(enemyPosition);
            DestroyEnemy();
        }
    }      

    private void DestroyEnemy()
    {
        StartCoroutine(DestroyWithDelay(_delayBeforeDeath));        
    }

    private IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _enemy.Destroy();
    }
}