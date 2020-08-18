using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private bool _isBadApple = false;

    public int Reward => _reward;
    public bool IsBadApple => _isBadApple;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Basket basket))
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.TryGetComponent(out Destroyer destroyer))
            gameObject.SetActive(false);
    }
}
