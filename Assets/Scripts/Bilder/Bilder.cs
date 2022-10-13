using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Bilder : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _pointer;

    public event Action<List<Vector3>> TransferPositon;
    public event Action StartDraw;


    private List<Vector3> _points;
    private LineRenderer _line;
    private bool _enabled = true;
    private bool _startPositon = false;

    private void Awake()
    {
        _points = new List<Vector3>();
        _line = GetComponent<LineRenderer>();
        _line.startWidth = 0.5f;
        _line.endWidth = 0.5f;
        _line.positionCount = 0;
    }

    private void Update()
    {
        FindingPositionsDraw();

        if (Input.GetMouseButton(0) && _enabled)
        {
            BildingSiteSearch();
            StartDraw?.Invoke();
        }
        else if (Input.GetMouseButtonUp(0) && _startPositon)
        {
            TransferPositon?.Invoke(_points);
            _startPositon = false;
            _enabled = false;
        }
    }

    private void FindingPositionsDraw()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.TryGetComponent<PointStart>(out PointStart start))
            {
                start.transform.position = hit.point;
                _startPositon = true;
            }
        }
    }

    private void BildingSiteSearch()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.TryGetComponent<Plane>(out Plane plane)&& _startPositon)
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
