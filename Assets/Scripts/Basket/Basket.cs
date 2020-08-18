using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Basket : MonoBehaviour
{
    public event UnityAction<int, bool> AppleCaught;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Apple apple))
        {
            AppleCaught?.Invoke(apple.Reward, apple.IsBadApple);
        }
    }
}
