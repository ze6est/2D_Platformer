using System.Collections;
using UnityEngine;

public class DestroyerEnemy : MonoBehaviour
{
    private Enemy _enemy;
    private float _delayBeforeDeath = 0.3f;

    private void Awake()
    {
        _enemy = gameObject.GetComponentInParent<Enemy>();
    }

    private void OnEnable()
    {        
        _enemy.EncounteredWithPlayer += OnDestroyEnemy;
    }

    private void OnDisable()
    {
        _enemy.EncounteredWithPlayer -= OnDestroyEnemy;
    }

    private void OnDestroyEnemy()
    {
        StartCoroutine(DestroyWithDelay(_delayBeforeDeath));        
    }

    private IEnumerator DestroyWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject.transform.parent.gameObject);
    }
}