using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class KeyboardInput : MonoBehaviour
{    
    private Player _player;
    private UnityEvent _jumped = new UnityEvent();
    private UnityEvent _standing = new UnityEvent();    
    private UnityEvent _ranRight = new UnityEvent();
    private UnityEvent _ranLeft = new UnityEvent();

    public event UnityAction Jumped
    {
        add => _jumped.AddListener(value);
        remove => _jumped.RemoveListener(value);
    }

    public event UnityAction Standing
    {
        add => _standing.AddListener(value);
        remove => _standing.RemoveListener(value);
    }    

    public event UnityAction RanRight
    {
        add => _ranRight.AddListener(value);
        remove => _ranRight.RemoveListener(value);
    }

    public event UnityAction RanLeft
    {
        add => _ranLeft.AddListener(value);
        remove => _ranLeft.RemoveListener(value);
    }

    private void Awake()
    {        
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _standing.Invoke();

        if (Input.GetKey(KeyCode.RightArrow) && _player.PlayerIsAlive)
        {            
            _ranRight.Invoke();
        }        

        if (Input.GetKey(KeyCode.LeftArrow) && _player.PlayerIsAlive)
        {            
            _ranLeft.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Space) && _player.IsGround && _player.PlayerIsAlive)
        {
            _jumped.Invoke();
        }        
    }      
}