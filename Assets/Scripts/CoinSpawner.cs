using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = gameObject.GetComponent<Enemy>();
    }

    private void OnEnable()
    {        
        _enemy.EncounteredWithPlayer += OnCreate;
    }

    private void OnDisable()
    {
        _enemy.EncounteredWithPlayer -= OnCreate;
    }

    public void OnCreate()
    {
        Instantiate(_coin, _enemy.transform);
    }
}
