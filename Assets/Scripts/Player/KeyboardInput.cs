using UnityEngine;

[RequireComponent(typeof(Mover))]
[RequireComponent(typeof(Player))]
[RequireComponent(typeof(SpriteRenderer))]
public class KeyboardInput : MonoBehaviour
{     
    [SerializeField] private PlayerAnimator _playerAnimator;

    private Mover _mover;
    private Player _player;
    private Fountain _fountain;
    private SpriteRenderer _spriteRenderer;
    private bool _playerIsAlive = true;
    private float _speedIdle = 0f;
    private float _speedWalk = 1f;    
    private int _directionRight = 1;
    private int _directionLeft = -1;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _player = GetComponent<Player>();
        _fountain = FindObjectOfType<Fountain>();
        _spriteRenderer = GetComponent<SpriteRenderer>();       
    }

    private void OnEnable()
    {
        _player.Destroyed += DisableManagement;
        _fountain.ReachedEndLevel += DisableManagement;
    }

    private void OnDisable()
    {
        _player.Destroyed -= DisableManagement;
        _fountain.ReachedEndLevel -= DisableManagement;
    }

    private void Update()
    {
        _playerAnimator.Run(_speedIdle);        

        if (Input.GetKey(KeyCode.RightArrow) && _playerIsAlive)
        {
            Move(_speedWalk, false, _directionRight);            
        }        

        if (Input.GetKey(KeyCode.LeftArrow) && _playerIsAlive)
        {
            Move(_speedWalk, true, _directionLeft);
        }

        if(Input.GetKeyDown(KeyCode.Space) && _player.IsGround && _playerIsAlive)
        {            
            _playerAnimator.Jump();
            _mover.Jump();
            _player.Jumped();
        }        
    }

    private void Move(float speedWalk, bool flip, int direction)
    {
        _playerAnimator.Run(speedWalk);
        _spriteRenderer.flipX = flip;
        _mover.Move(direction);
    }

    private void DisableManagement()
    {
        _playerIsAlive = false;
    }
}