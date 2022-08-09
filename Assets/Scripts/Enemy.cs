using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private UnityEvent _encounteredWithPlayer;

    public event UnityAction EncounteredWithPlayer
    {
        add => _encounteredWithPlayer.AddListener(value);
        remove => _encounteredWithPlayer.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Player>(out Player player)) 
        {
            _encounteredWithPlayer.Invoke();
        }
    }
}
