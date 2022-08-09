using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(SpriteRenderer))]
public class KeyboardInput : MonoBehaviour
{     
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Mover _mover;
    private SpriteRenderer _spriteRenderer;
    private float _speedIdle = 0f;
    private float _speedWalk = 1f;    
    private int _directionRight = 1;
    private int _directionLeft = -1;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _spriteRenderer = GetComponent<SpriteRenderer>();       
    }

    private void Update()
    {
        _playerAnimator.Run(_speedIdle);        

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(_speedWalk, false, _directionRight);            
        }        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(_speedWalk, true, _directionLeft);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {            
            _playerAnimator.Jump();
            _mover.Jump();
        }        
    }

    private void Move(float speedWalk, bool flip, int direction)
    {
        _playerAnimator.Run(speedWalk);
        _spriteRenderer.flipX = flip;
        _mover.Move(direction);
    }
}