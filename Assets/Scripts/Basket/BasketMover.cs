using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMover : MonoBehaviour
{
    [SerializeField] private int _speed;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private Vector2 _targetPosition;
    private Vector2 _mouseScreenPosition;
    private Vector2 _mouseWorldPosition;

    private void Update()
    {
        _mouseScreenPosition = Input.mousePosition;
        _mouseWorldPosition = Camera.main.ScreenToWorldPoint(_mouseScreenPosition);

        _targetPosition = new Vector2(_mouseWorldPosition.x, transform.position.y);

        CheckTargetPosition(_leftBorder, _rightBorder);
        MoveToMouse();
    }

    private void MoveToMouse()
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
}
