using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LinearColorChanger))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(KeyboardInput))]
public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _soundJump;
    [SerializeField] private AudioClip _soundTakingDamage;
    [SerializeField] private AudioClip _soundKillingEnemy;
    [SerializeField] private AudioClip _soundTookCoin;    

    private DestroyerEnemy[] _enemies;
    private Camera _camera;
    private LinearColorChanger _linearColorChanger;
    private AudioSource _audioSource;
    private int _health = 3;
    private int _money = 0;
    private UnityEvent _destroyed = new UnityEvent();

    public event UnityAction Destroyed
    {
        add => _destroyed.AddListener(value);
        remove => _destroyed.RemoveListener(value);
    }

    public bool IsGround { get; private set; }

    private void Awake()
    {
        _enemies = FindObjectsOfType<DestroyerEnemy>();
        _camera = GetComponentInChildren<Camera>();
        _linearColorChanger = GetComponent<LinearColorChanger>();
        _audioSource = GetComponent<AudioSource>();
        IsGround = false;
    }

    private void OnEnable()
    {
        foreach(DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed += PlaySoundMurder;
        }
    }

    private void OnDisable()
    {
        foreach (DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed -= PlaySoundMurder;
        }
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
            _audioSource.PlayOneShot(_soundTookCoin);
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

    public void Jumped()
    {
        _audioSource.PlayOneShot(_soundJump);
        IsGround = false;
    }

    private void TakeDamage()
    {
        _audioSource.PlayOneShot(_soundTakingDamage);
        _health--;
        _linearColorChanger.StartColorChanging();

        if (_health <= 0)
        {
            _camera.transform.parent = null;
            _destroyed.Invoke();            
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    private void PlaySoundMurder()
    {
        _audioSource.PlayOneShot(_soundKillingEnemy);
    }
}