using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasketMoverMobile : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private Vector2 _targetPosition;
    private Vector2 _fingerScreenPosition;
    private Vector2 _fingerWorldPosition;

   

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            _fingerScreenPosition = touch.position;

            _fingerWorldPosition = Camera.main.ScreenToWorldPoint(_fingerScreenPosition);

            _targetPosition = new Vector2(_fingerWorldPosition.x, transform.position.y);

            CheckTargetPosition(_leftBorder, _rightBorder);
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private void CheckTargetPosition(Transform leftBorder, Transform rightBorder)
    {
        if (_targetPosition.x >= rightBorder.position.x)
        {
            _targetPosition.x = rightBorder.position.x;
        }
        else if (_targetPosition.x <= leftBorder.position.x)
        {
            _targetPosition.x = leftBorder.position.x;
        }
    }


    private void CheckTouch()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
        }
    }

}
