using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Basket))]
public class ScoreChanger : MonoBehaviour
{
    [SerializeField] private Text _score;
    [SerializeField] private Destroyer _destroyer;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _caughtAudioClip;
    [SerializeField] private AudioClip _fellAudioClip;

    private int _scoreValue = 0;
    private Basket basket;

    public int ScoreValue => _scoreValue;
    public event UnityAction<int> ScoreIncreased;

    private void OnEnable()
    {
        basket = GetComponent<Basket>();
        basket.AppleCaught += OnAppleCaught;

        _destroyer.AppleFell += OnAppleFell;
    }

    private void OnDisable()
    {
        basket.AppleCaught -= OnAppleCaught;
        _destroyer.AppleFell -= OnAppleFell;
    }

    private void Start()
    {
        _score.text = "Счёт: " + _scoreValue.ToString();
    }

    private void OnAppleCaught(int reward, bool isBadApple)
    {
        ScoreIncreased?.Invoke(_scoreValue);

        _scoreValue += reward;
        _score.text = "Счёт: " + _scoreValue.ToString();

        _audioSource.PlayOneShot(_caughtAudioClip);

        if(isBadApple)
            _audioSource.PlayOneShot(_fellAudioClip);
    }

    private void OnAppleFell(int reward, bool isBadApple)
    {
        ScoreIncreased?.Invoke(_scoreValue);

        if (!isBadApple)
        {
            _scoreValue -= reward;
            _score.text = "Счёт: " + _scoreValue.ToString();
        }

        if(isBadApple)
            _audioSource.PlayOneShot(_fellAudioClip);
    }
}
