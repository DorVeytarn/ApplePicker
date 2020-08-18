using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawnedObject = Instantiate(prefab, _container);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject spawnedObject = Instantiate(prefabs[randomIndex], _container);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(spawnedObject => spawnedObject.activeSelf == false);

        return result != null;
    }
}
