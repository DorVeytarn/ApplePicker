using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ScoreChanger))]
public class PurposeDisplay : MonoBehaviour
{
    [SerializeField] private Text _purposeText;

    private ScoreChanger _scoreChanger;
    private int _purposeValue = 10;

    public event UnityAction<float> PurposeAchived;
    public int PurposeValue => _purposeValue;

    private void OnEnable()
    {
        _scoreChanger = GetComponent<ScoreChanger>();
        _scoreChanger.ScoreIncreased += TryChangePurpose;
    }

    private void OnDisable()
    {
        _scoreChanger.ScoreIncreased -= TryChangePurpose;
    }

    private void Start()
    {
        _purposeText.text = "Цель: " + _purposeValue.ToString();
    }

    private void TryChangePurpose(int scoreValue)
    {
        if (scoreValue >= _purposeValue)
        {
            _purposeValue = Mathf.RoundToInt(_purposeValue * 1.5f);
            _purposeText.text = "Цель: " + _purposeValue.ToString();

            PurposeAchived?.Invoke(_purposeValue);
        }
    }

    
}
