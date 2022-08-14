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
        _player.Destroyed += PlaySoundLosing;
        _keyboardInput.Jumped += PlaySoundJump;
        _player.DamageTaken += PlaySoundTakingDamage;
        _fountain.ReachedEndLevel += PlaySoundWinning;
        _player.CoinTaken += PlaySounTookCoin;

        foreach (DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed += PlaySounKillinEnemy;
        }
    }

    private void OnDisable()
    {
        _player.Destroyed -= PlaySoundLosing;
        _keyboardInput.Jumped -= PlaySoundJump;
        _player.DamageTaken -= PlaySoundTakingDamage;
        _fountain.ReachedEndLevel -= PlaySoundWinning;
        _player.CoinTaken -= PlaySounTookCoin;

        foreach (DestroyerEnemy enemy in _enemies)
        {
            enemy.Destroyed -= PlaySounKillinEnemy;
        }
    }    

    private void PlaySoundLosing()
    {
        _soundsAudioSource.PlayOneShot(_soundLosing);
    }

    private void PlaySoundWinning()
    {
        _soundsAudioSource.PlayOneShot(_soundLosing);
    }

    private void PlaySoundJump()
    {
        _soundsAudioSource.PlayOneShot(_soundJump);
    }

    private void PlaySoundTakingDamage()
    {
        _soundsAudioSource.PlayOneShot(_soundTakingDamage);
    }

    private void PlaySounKillinEnemy()
    {
        _soundsAudioSource.PlayOneShot(_soundKillingEnemy);
    }

    private void PlaySounTookCoin()
    {
        _soundsAudioSource.PlayOneShot(_soundTookCoin);
    }
}