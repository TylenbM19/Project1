using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Bilder _lineDraw;

    private List<Vector3> _points;
    private float _speed = 3f;
    private int _currentPoint = 0;

    private void Awake()
    {
        _points = new List<Vector3>();
    }

    private void Update()
    {
        if (_points != null)
        {
            Vector3 target = _points[_currentPoint];

            transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

            if (transform.position == target)
            {
                _currentPoint++;

                if (_currentPoint >= _points.Count)
                {
                    transform.position = _points[_currentPoint];
                }
            }
        }
    }

    private void OnEnable()
    {
        _lineDraw.Start += MovePoints;
    }

    private void OnDisable()
    {
        _lineDraw.Start -=MovePoints;
    }

    private void MovePoints(List<Vector3> point)
    {
        _points = point;
    }
}
