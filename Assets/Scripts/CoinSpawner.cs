using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;    

    public void CreateCoin(Vector2 spawnPosition)
    {
        Instantiate(_coin, spawnPosition, Quaternion.identity);
    }
}