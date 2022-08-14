using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private DestroyerEnemy[] _enemies;
    private float _delayBeforeDeath = 0.001f;

    private void OnEnable()
    {
        _enemies = GetComponentsInChildren<DestroyerEnemy>();

        foreach (DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed += DestroyEnemy;
        }
    }

    private void OnDisable()
    {
        foreach (DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed -= DestroyEnemy;
        }
    }

    private void DestroyEnemy()
    {
        StartCoroutine(DestroyWithDelay(_delayBeforeDeath));
    }

    private IEnumerator DestroyWithDelay(float delay)
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.enabled = false;
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }    
}