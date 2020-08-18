using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AppleMover : MonoBehaviour
{
    [SerializeField] private float _minCurrentGravityScale;
    [SerializeField] private float _maxCurrentGravityScale;

    private float _currentGravityScale;

    public float DifficultyScale = 1;

    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _currentGravityScale = Random.Range(_minCurrentGravityScale, _maxCurrentGravityScale);
        _rigidbody2D.gravityScale = _currentGravityScale * DifficultyScale;

    }
}
