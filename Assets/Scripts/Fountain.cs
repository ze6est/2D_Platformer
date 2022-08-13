using UnityEngine;
using UnityEngine.Events;

public class Fountain : MonoBehaviour 
{
    private UnityEvent _reachedEndLevel = new UnityEvent();

    public event UnityAction ReachedEndLevel
    {
        add => _reachedEndLevel.AddListener(value);
        remove => _reachedEndLevel.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            _reachedEndLevel.Invoke();
        }
    }
}