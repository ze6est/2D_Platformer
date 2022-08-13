using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundReproducer : MonoBehaviour
{
    [SerializeField] private AudioClip _soundLosing;
    [SerializeField] private AudioClip _soundWinning;
    [SerializeField] private AudioSource _sonndsdAudioSource;

    private Player _player;
    private Fountain _fountain;    

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _fountain = FindObjectOfType<Fountain>();        
    }

    private void OnEnable()
    {
        _player.Destroyed += PlaySoundLosing;
        _fountain.ReachedEndLevel += PlaySoundWinning;
    }

    private void OnDisable()
    {
        _player.Destroyed -= PlaySoundLosing;
        _fountain.ReachedEndLevel -= PlaySoundWinning;
    }    

    private void PlaySoundLosing()
    {
        _sonndsdAudioSource.PlayOneShot(_soundLosing);
    }

    private void PlaySoundWinning()
    {
        _sonndsdAudioSource.PlayOneShot(_soundLosing);
    }
}