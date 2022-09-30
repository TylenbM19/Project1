using System;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Bilder _bilder;

    private List<Vector2> _points = new List<Vector2>();
    private float _speed = 3f;
    private int _currentPoint = 0;

    public event Action StartMoving;
    public event Action EndMovemet;

    private void OnEnable()
    {
        _bilder.Start += GetPointPosition;
    }

    private void OnDisable()
    {
        _bilder.Start -= GetPointPosition;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (_points.Count != 0)
        {
            StartMoving?.Invoke();
            Vector3 target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

            if (transform.position == target)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Count)
                {
                    _points.Clear();
                    EndMovemet?.Invoke();
                }
            }
        }
    }

    private void GetPointPosition(List<Vector2> point)
    {
        _points = point;
    }
}
