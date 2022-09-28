using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class Bilder : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _pointer;

    public event UnityAction<List<Vector2>> Start;

    private List<Vector2> _points;
    private LineRenderer _line;
    private bool _enabled = true;

    private void Awake()
    {
        _points = new List<Vector2>();
        _line = GetComponent<LineRenderer>();
        _line.startWidth = 0.2f;
        _line.endWidth = 0.2f;
        _line.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _enabled)
        {
            BildingSiteSearch();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Start?.Invoke(_points);
            _enabled = false;
        }
    }

    private void BildingSiteSearch()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.TryGetComponent<Plane>(out Plane plane))
            {
                _pointer.position = hit.point;
                DrawLine(_pointer.position);
                _points.Add(_pointer.position);
            }
        }
    }

    private void DrawLine(Vector2 vector)
    {
        _line.positionCount++;
        _line.SetPosition(_line.positionCount - 1, vector);
    }
}
