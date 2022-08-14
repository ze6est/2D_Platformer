using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(KeyboardInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private Fountain _fountain;
    
    private Camera _camera;    
    
    private KeyboardInput _keyboardInput;
    private int _health = 3;
    private int _money = 0;
    private UnityEvent _destroyed = new UnityEvent();
    private UnityEvent _damageTaken = new UnityEvent();
    private UnityEvent _enemyKilled = new UnityEvent();
    private UnityEvent _coinTaken = new UnityEvent();

    public bool IsGround { get; private set; } = false;
    public bool PlayerIsAlive { get; private set; } = true;

    public event UnityAction Destroyed
    {
        add => _destroyed.AddListener(value);
        remove => _destroyed.RemoveListener(value);
    }

    public event UnityAction DamageTaken
    {
        add => _damageTaken.AddListener(value);
        remove => _damageTaken.RemoveListener(value);
    }

    public event UnityAction EnemyKilled
    {
        add => _enemyKilled.AddListener(value);
        remove => _enemyKilled.RemoveListener(value);
    }

    public event UnityAction CoinTaken
    {
        add => _coinTaken.AddListener(value);
        remove => _coinTaken.RemoveListener(value);
    }

    private void Awake()
    {        
        _camera = GetComponentInChildren<Camera>();
        _keyboardInput = GetComponent<KeyboardInput>();
    }

    private void OnEnable()
    {
        _fountain.ReachedEndLevel += DisableController;
        _keyboardInput.Jumped += BlockJump;
    }

    private void OnDisable()
    {
        _fountain.ReachedEndLevel += DisableController;
        _keyboardInput.Jumped -= BlockJump;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Enemy>(out Enemy enemy))
        {            
            TakeDamage();
        }
        
        if(collider.TryGetComponent<Bullet>(out Bullet bullet))
        {            
            TakeDamage();
            Destroy(bullet.gameObject);
        }

        if(collider.TryGetComponent<Coin>(out Coin coin))
        {
            _coinTaken.Invoke();
            _money++;
            Destroy(coin.gameObject);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<CompositeCollider2D>(out CompositeCollider2D composite))
        {
            IsGround = true;
        }                
    }    

    private void TakeDamage()
    {
        _damageTaken.Invoke();
        _health--;        

        if (_health <= 0)
        {
            DisableController();
            _camera.transform.parent = null;
            _destroyed.Invoke();            
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }    
    
    private void DisableController()
    {
        PlayerIsAlive = false;
    }

    private void BlockJump()
    {
        IsGround = false;
    }
}