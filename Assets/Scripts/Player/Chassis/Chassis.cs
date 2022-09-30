using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chassis : MonoBehaviour
{
    [SerializeField] private Move _move;
    [SerializeField] private Player _player;
    [SerializeField] private Wheel[] _wheels;

    private void OnEnable()
    {
        _move.StartMoving += StartMachineProcess;
        _move.EndMovemet += ReachedEndPoint;
    }

    private void OnDisable()
    {
        _move.StartMoving -= StartMachineProcess;
        _move.EndMovemet -= ReachedEndPoint;
    }

    private void StartMachineProcess()
    {
        foreach(var wheel in _wheels)
        {
            wheel.EnableRotation();
        }
    }

    private void ReachedEndPoint()
    {
        _player.Unhook();
    }
}
