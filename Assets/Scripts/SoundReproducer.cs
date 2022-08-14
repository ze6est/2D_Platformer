using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundReproducer : MonoBehaviour
{
    [SerializeField] private AudioClip _soundLosing;
    [SerializeField] private AudioClip _soundWinning;
    [SerializeField] private AudioClip _soundJump;
    [SerializeField] private AudioClip _soundTakingDamage;
    [SerializeField] private AudioClip _soundKillingEnemy;
    [SerializeField] private AudioClip _soundTookCoin;
    [SerializeField] private AudioSource _soundsAudioSource;
    [SerializeField] private Player _player;    
    [SerializeField] private Fountain _fountain;
    [SerializeField] private KeyboardInput _keyboardInput;
    [SerializeField] private GameObject _enemiesContainer;

    private DestroyerEnemy[] _enemies;

    private void OnEnable()
    {
        _enemies = _enemiesContainer.GetComponentsInChildren<DestroyerEnemy>();
        _player.Destroyed += () => PlaySound(_soundLosing);
        _keyboardInput.Jumped += () => PlaySound(_soundJump);
        _player.DamageTaken += () => PlaySound(_soundTakingDamage);
        _fountain.ReachedEndLevel += () => PlaySound(_soundWinning);
        _player.CoinTaken += () => PlaySound(_soundTookCoin);

        foreach (DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed += () => PlaySound(_soundKillingEnemy);
        }
    }

    private void OnDisable()
    {
        _player.Destroyed -= () => PlaySound(_soundLosing);
        _keyboardInput.Jumped -= () => PlaySound(_soundJump);
        _player.DamageTaken -= () => PlaySound(_soundTakingDamage);
        _fountain.ReachedEndLevel -= () => PlaySound(_soundWinning);
        _player.CoinTaken -= () => PlaySound(_soundTookCoin);

        foreach (DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed -= () => PlaySound(_soundKillingEnemy);
        }
    }
    
    private void PlaySound(AudioClip audioClip)
    {
        _soundsAudioSource.PlayOneShot(audioClip);
    }
}