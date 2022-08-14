using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private KeyboardInput _keyboardInput;

    public bool PlayerOnGround { get; private set; } = false;

    private void OnEnable()
    {        
        _keyboardInput.Jumped += BlockJump;
    }

    private void OnDisable()
    {
        _keyboardInput.Jumped -= BlockJump;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            PlayerOnGround = true;
        }
    }

    private void BlockJump()
    {
        PlayerOnGround = false;
    }
}