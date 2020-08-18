using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PurposeDisplay))]
public class DifficultyChanger : MonoBehaviour
{
    [SerializeField] private AppleMover _apple;
    [SerializeField] private AppleMover _appleSlow;
    [SerializeField] private AppleMover _appleBadSlow;
    [SerializeField] private AppleMover _appleBadFast;

    private ScoreChanger _scoreChanger;

    private void OnEnable()
    {
        _scoreChanger = GetComponent<ScoreChanger>();
        _scoreChanger.ScoreIncreased += ChangeDifficult;
    }

    private void OnDisable()
    {
        _scoreChanger.ScoreIncreased -= ChangeDifficult;
    }

    private void ChangeDifficult(int scoreValue)
    {
        if ( scoreValue >= 20 && scoreValue < 30)
        {
            _apple.DifficultyScale = 1.23f;
            _appleSlow.DifficultyScale = 1.23f;
            _appleBadSlow.DifficultyScale = 1.23f;
            _appleBadFast.DifficultyScale = 1.23f;
        }
        if (scoreValue >= 30 && scoreValue < 50)
        {
            _apple.DifficultyScale = 1.3f;
            _appleSlow.DifficultyScale = 1.3f;
            _appleBadSlow.DifficultyScale = 1.3f;
            _appleBadFast.DifficultyScale = 1.3f;
        }
        if (scoreValue >= 50 && scoreValue < 90)
        {
            _apple.DifficultyScale = 1.4f;
            _appleSlow.DifficultyScale = 1.4f;
            _appleBadSlow.DifficultyScale = 1.4f;
            _appleBadFast.DifficultyScale = 1.4f;
        }
        if (scoreValue >= 90)
        {
            _apple.DifficultyScale = 1.6f;
            _appleSlow.DifficultyScale = 1.6f;
            _appleBadSlow.DifficultyScale = 1.6f;
            _appleBadFast.DifficultyScale = 1.6f;
        }
    }
}
