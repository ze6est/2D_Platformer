using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(SpriteRenderer))]
public class LinearColorChanger : MonoBehaviour
{
    [SerializeField] private float _rateChange = 0.5f;
    [SerializeField] private Color _targetColor;

    private Player _player;
    private SpriteRenderer _target;
    private Color _startColor;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.DamageTaken += StartColorChanging;
    }

    private void OnDisable()
    {
        _player.DamageTaken -= StartColorChanging;
    }

    private void Start()
    {        
        _target = GetComponent<SpriteRenderer>();
        _startColor = _target.color;
    }

    public void StartColorChanging()
    {
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        _target.color = Color.Lerp(_startColor, _targetColor, _rateChange);
        yield return new WaitForSeconds(_rateChange);
        _target.color = _startColor;
    }
}