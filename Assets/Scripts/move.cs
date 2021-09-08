using System;
using UnityEngine;


public class move : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;
    private Transform _finishPosition;
    private Transform[] _points;
    private GameObject[] _gears;
    private float _speed;
    private Vector3 _target;
    private int _breakpointNumber = 1;
    private bool directionOfMovement = true;
    System.Random rnd = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        _points = gameManager.Points;
        _gears = gameManager.Gears;
        transform.position = _points[0].position;
        _target = _points[_breakpointNumber].position;
        _finishPosition = _points[Array.IndexOf(_gears, this.gameObject) + 1];
        _speed = Array.IndexOf(_gears, this.gameObject) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLocation();
        Rotation();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * _speed);
    }

    /// <summary>
    /// Проверяет направление движения и определяет следующую точку движения, с каждой точкой случайно меняет скорость.
    /// </summary>
    private void CheckLocation()
    {
        if (directionOfMovement)
        {
            if (transform.position == _target && transform.position != _finishPosition.position)
            {
                _breakpointNumber++;
                _target = _points[_breakpointNumber].position;
            }
            else if (transform.position == _finishPosition.position)
            {
                directionOfMovement = false;
            }
            Move();
        }
        else
        {
            if (transform.position == _target && transform.position != _points[0].position)
            {
                _breakpointNumber--;
                _target = _points[_breakpointNumber].position;
            }
            else if (transform.position == _points[0].position)
            {
                directionOfMovement = true;
            }
            Move();
        }
    }

    private void Rotation()
    {
        transform.Rotate(0, _speed, 0);
    }

}
