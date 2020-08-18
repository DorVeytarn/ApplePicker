using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _chanceToChangeDirection;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    private Vector2 _direction;
    private bool _chanceToChangeDirectionCheker;

    private void Start()
    {
        _chanceToChangeDirectionCheker = RandomChecher(_chanceToChangeDirection);
        _direction = Vector2.left;
    }

    private void FixedUpdate()
    {
        _chanceToChangeDirectionCheker = RandomChecher(_chanceToChangeDirection);
    }

    private void Update()
    {
        _direction = ChangeDirection(_leftBorder, _rightBorder);
        Move(_direction, _speed);
    }

    private void Move(Vector2 direction, float speed)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private Vector2 ChangeDirection(Transform leftBorder, Transform rigthBorder)
    {
        if (transform.position.x <= leftBorder.position.x)
            return _direction = Vector2.right;
        else if (transform.position.x >= rigthBorder.position.x)
            return _direction = Vector2.left;
        else if (_chanceToChangeDirectionCheker)
            return _direction = new Vector2(_direction.x * -1, _direction.y);
        else return _direction;
    }

    private bool RandomChecher(float valueChance)
    {
        if (Random.value < valueChance)
            return true;
        else return false;
    }

}
