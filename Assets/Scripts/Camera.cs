using UnityEngine;

public class Camera : MonoBehaviour
{
    private Player _player;

    private void OnEnable()
    {
        _player = GetComponentInParent<Player>();
        _player.Destroyed += Disconnect;
    }

    private void OnDisable()
    {
        _player.Destroyed -= Disconnect;
    }

    private void Disconnect()
    {
        transform.parent = null;
    }
}