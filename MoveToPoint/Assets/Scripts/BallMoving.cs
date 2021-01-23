using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BallMoving : MonoBehaviour
{
    private float _speed;

    private List<Vector2> _destinations;
    private Vector2 _currentDestination;
    private LineRenderer _renderer;
    private Camera _cam;

    void Start()
    {
        _destinations = new List<Vector2>();
        _renderer = GetComponent<LineRenderer>();
        _cam = Camera.main;
    }

    void Update()
    {
        ListenForCommands();
        ExecuteCommand();
        DrawTrajectory();
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    private void ListenForCommands()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _destinations.Add(_cam.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void ExecuteCommand()
    {
        if (_currentDestination != null)
        {
            Vector2 offset = new Vector2(transform.position.x, transform.position.y) - _currentDestination;
            float sqrLen = offset.sqrMagnitude;
            if (sqrLen < 0.01)
            {
                if (_destinations.Count == 0)
                    return;
                _currentDestination = _destinations[0];
                _destinations.RemoveAt(0);
            }
            transform.position = Vector2.MoveTowards(transform.position, _currentDestination, _speed * Time.deltaTime);
            return;
        }
    }

    private void DrawTrajectory()
    {
        _renderer.positionCount = _destinations.Count + 2;

        for (int i = 0; i < _destinations.Count; i++)
        {
            _renderer.SetPosition(i, _destinations[_destinations.Count - i - 1]);
        }
        Debug.Log(_destinations);
        _renderer.SetPosition(_destinations.Count, _currentDestination);   
        _renderer.SetPosition(_destinations.Count + 1, transform.position);
    }
}