using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{    
    private Animator _animator;
    private int _speedHash = Animator.StringToHash("speedTransition");
    private int _jumpHash = Animator.StringToHash("jump");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }    

    public void Run(float speed)
    {
        _animator.SetFloat(_speedHash, speed);
    }

    public void Jump()
    {
        _animator.SetTrigger(_jumpHash);
    }
}