using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _placeShot;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _delayFirstAction = 0.2f;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(_delayFirstAction);

        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (true)
        {
            Instantiate(_bullet, _placeShot.transform);

            yield return waitForSeconds;
        }        
    }
}
