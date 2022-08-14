using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Fountain _fountain;
        
    private int _health = 3;
    private int _money = 0;
    
    public bool PlayerIsAlive { get; private set; } = true;

    public event UnityAction Destroyed;
    public event UnityAction DamageTaken;
    public event UnityAction CoinTaken;

    private void OnEnable()
    {
        _fountain.ReachedEndLevel += DisableController;        
    }

    private void OnDisable()
    {
        _fountain.ReachedEndLevel += DisableController;        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Enemy>(out Enemy enemy) || collider.TryGetComponent<Bullet>(out Bullet bullet))
        {            
            TakeDamage();
        }

        if(collider.TryGetComponent<Coin>(out Coin coin))
        {
            CoinTaken.Invoke();
            _money++;            
        }        
    }     

    private void TakeDamage()
    {
        DamageTaken.Invoke();
        _health--;        

        if (_health <= 0)
        {
            DisableController();            
            Destroyed.Invoke();            
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }    
    
    private void DisableController()
    {
        PlayerIsAlive = false;
    }    
}