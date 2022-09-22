using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(LineRenderer))]
public class Bilder : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _pointer;

    public event UnityAction<List<Vector3>> Start;

    private List<Vector3> _points;
    private LineRenderer _line;


    private void Awake()
    {
        _points = new List<Vector3>();
        _line = GetComponent<LineRenderer>();
        _line.startWidth = 0.2f;
        _line.endWidth = 0.2f;
        _line.positionCount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            BildingSiteSearch();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Start?.Invoke(_points);
        }
    }

    //private void SavePositon()
    //{
    //    Vector3 currentPoint = GetWorldCoordinate(Input.mousePosition);
    //}

    //private Vector3 GetWorldCoordinate(Vector3 mousePosition)
    //{
    //    Vector3 mousePoint = new Vector3(mousePosition.x,1, 1);
    //    return _camera.ScreenToWorldPoint(mousePoint);
    //}

    private void BildingSiteSearch()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);

        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach(RaycastHit hit in hits)
        {
            if (hit.transform.TryGetComponent<Plane>(out Plane plane))
            {
                _pointer.position = hit.point;
                _points.Add(_pointer.position);
            }  
        }
    }
}
