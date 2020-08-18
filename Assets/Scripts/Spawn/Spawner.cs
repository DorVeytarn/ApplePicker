using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _maxDelay;
    [SerializeField] private float _minDelay;

    private float _elapsedTime;

    private void Start()
    {
        Initialize(_template);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        float delay = Random.Range(_minDelay, _maxDelay);
        if (_elapsedTime >= delay)
        {
            if (TryGetObject(out GameObject template))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetTemplate(template, _spawnPoints[spawnPointNumber].position);

            }
        }
    }

    private void SetTemplate(GameObject template, Vector2 spawnPoint)
    {
        template.SetActive(true);

        template.transform.position = spawnPoint;
    }
}
