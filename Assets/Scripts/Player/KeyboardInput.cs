using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private Ground _ground;

    private Player _player;

    public event UnityAction Jumped;
    public event UnityAction Standing;
    public event UnityAction RanRight;
    public event UnityAction RanLeft;    

    private void Awake()
    {        
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Standing.Invoke();

        if (Input.GetKey(KeyCode.RightArrow) && _player.PlayerIsAlive)
        {
            RanRight.Invoke();            
        }        

        if (Input.GetKey(KeyCode.LeftArrow) && _player.PlayerIsAlive)
        {
            RanLeft.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Space) && _ground.PlayerOnGround && _player.PlayerIsAlive)
        {
            Jumped.Invoke();
        }        
    }      
}