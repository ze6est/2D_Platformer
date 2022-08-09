using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _direction = -1;

    private void Update()
    {
        Move(_direction);
    }   

    private void Move(int direction)
    {
        transform.Translate(_speed * direction * Time.deltaTime, 0, 0);
    }
}
