using System;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Bilder _bilder;

    private List<Vector3> _points = new List<Vector3>();
    private float _speed = 20f;
    private int _currentPoint = 0;

    public event Action StartMoving;
    public event Action EndMovemet;

    private void OnEnable()
    {
        _bilder.TransferPositon += GetPointPosition;
    }

    private void OnDisable()
    {
        _bilder.TransferPositon -= GetPointPosition;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {

        if (_points.Count != 0)
        {
            StartMoving?.Invoke();
            Vector3 target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) <= 0.01f)
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

    private void GetPointPosition(List<Vector3> point)
    {
        _points = point;
    }
}
