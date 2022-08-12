using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;    

    private void Awake()
    {        
        _rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    public void Move(int direction)
    {
        transform.Translate(_speed * direction * Time.deltaTime, 0, 0);
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce);        
    }
}