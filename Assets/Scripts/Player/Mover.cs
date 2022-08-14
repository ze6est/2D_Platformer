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

    public event UnityAction Ran;    

    private void Awake()
    {        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _keyboardInput = GetComponent<KeyboardInput>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _keyboardInput.Jumped += Jump;
        _keyboardInput.RanRight += () => Move(false, _directionRight);
        _keyboardInput.RanLeft += () => Move(true, _directionLeft);
    }

    private void OnDisable()
    {
        _keyboardInput.Jumped -= Jump;
        _keyboardInput.RanRight -= () => Move(false, _directionRight);
        _keyboardInput.RanLeft -= () => Move(true, _directionLeft);
    }    

    private void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);        
    }

    private void Move(bool flipXOn, int direction)
    {
        _spriteRenderer.flipX = flipXOn;
        Ran.Invoke();
        transform.Translate(_speed * direction * Time.deltaTime, 0, 0);
    }
}