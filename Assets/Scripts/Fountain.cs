using UnityEngine;
using UnityEngine.Events;

public class Fountain : MonoBehaviour 
{
    public event UnityAction ReachedEndLevel;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            ReachedEndLevel.Invoke();
        }
    }
}