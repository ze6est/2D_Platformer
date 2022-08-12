using UnityEngine;

public class Coin : MonoBehaviour
{
    private float _offset = 0.5f;

    private void OnEnable()
    {
        transform.position = new Vector2(transform.position.x + _offset, transform.position.y - _offset);
    }
}