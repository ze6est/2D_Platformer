using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(KeyboardInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private KeyboardInput _keyboardInput;
    private SpriteRenderer _spriteRenderer;
    private int _directionRight = 1;
    private int _directionLeft = -1;
    private UnityEvent _ran = new UnityEvent();

    public event UnityAction Ran
    {
        add => _ran.AddListener(value);
        remove => _ran.RemoveListener(value);
    }

    private void Awake()
    {        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _keyboardInput = GetComponent<KeyboardInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _keyboardInput.Jumped += Jump;
        _keyboardInput.RanRight += MoveRight;
        _keyboardInput.RanLeft += MoveLeft;
    }

    private void OnDisable()
    {
        _keyboardInput.Jumped -= Jump;
        _keyboardInput.RanRight -= MoveRight;
        _keyboardInput.RanLeft -= MoveLeft;
    }

    private void MoveRight()
    {
        _spriteRenderer.flipX = false;
        _ran.Invoke();
        transform.Translate(_speed * _directionRight * Time.deltaTime, 0, 0);
    }

    private void MoveLeft()
    {
        _spriteRenderer.flipX = true;
        _ran.Invoke();
        transform.Translate(_speed * _directionLeft * Time.deltaTime, 0, 0);
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);        
    }
}