using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(KeyboardInput))]
[RequireComponent(typeof(Mover))]
public class PlayerAnimator : MonoBehaviour
{ 
    private Animator _animator;
    private KeyboardInput _keyboardInput;
    private Mover _mover;
    private int _speedHash = Animator.StringToHash("speedTransition");
    private int _jumpHash = Animator.StringToHash("jump");
    private float _speedIdle = 0f;
    private float _speedWalk = 1f;

    private void OnEnable()
    {
        _keyboardInput = GetComponent<KeyboardInput>();
        _mover = GetComponent<Mover>();
        _keyboardInput.Jumped += Jump;
        _keyboardInput.Standing += Stand;
        _mover.Ran += Run;
    }

    private void OnDisable()
    {
        _keyboardInput.Jumped -= Jump;
        _keyboardInput.Standing -= Stand;
        _mover.Ran -= Run;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Stand()
    {
        _animator.SetFloat(_speedHash, _speedIdle);
    }

    public void Run()
    {
        _animator.SetFloat(_speedHash, _speedWalk);
    }

    public void Jump()
    {
        _animator.SetTrigger(_jumpHash);
    }
}