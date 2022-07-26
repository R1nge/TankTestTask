using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;
    private Camera _camera;

    private void Awake() => _camera = Camera.main;

    private void Start() => GetScreenBoundaries();

    private void GetScreenBoundaries()
    {
        var height = _camera.orthographicSize;
        var width = height * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        _maxX = width;
        _minX = width - _maxX * 2;
        _maxY = height;
        _minY = height - _maxY * 2;
    }

    private void LateUpdate() => CheckBorders();

    private void CheckBorders()
    {
        var v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, _minX, _maxX);
        v3.y = Mathf.Clamp(v3.y, _minY, _maxY);
        transform.position = v3;
    }
}