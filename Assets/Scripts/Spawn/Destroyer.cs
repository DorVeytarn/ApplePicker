using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destroyer : MonoBehaviour
{
    private Apple apple;

    public event UnityAction<int, bool> AppleFell;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Apple apple))
        {
            if (!apple.IsBadApple)
                AppleFell?.Invoke(apple.Reward, apple.IsBadApple);
            else if (apple.IsBadApple)
                AppleFell?.Invoke(apple.Reward/2, apple.IsBadApple);

        }
    }

}
