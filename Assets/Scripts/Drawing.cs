using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    [SerializeField] private Collider _drawingArea;
    [SerializeField] private float _deep;
    [SerializeField] private GameObject _line;

    private LineRenderer _lineRenderer;
    private Camera _camera;
    private List<LineRenderer> _lines;
    private Color _currentColor;

    private void Awake()
    {
        _camera = Camera.main;
        _lines = new List<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrawingNewLine();
        }
        
        if (Input.GetMouseButton(0) && _lineRenderer != null)
        {
            ContinueDrawing();
        }
    }

    public void SetColor(Color buttonColor)
    {
        _currentColor = buttonColor;
    }

    public void EraseEverything()
    {
        foreach (var lineRenderer in _lines)
        {
            Destroy(lineRenderer.gameObject);
        }
        
        _lines.Clear();
    }

    private void StartDrawingNewLine()
    {
        var newLine = Instantiate(_line);
        _lineRenderer = newLine.GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 0;
        _lineRenderer.startColor = _currentColor;
        _lineRenderer.endColor = _currentColor;
        _lines.Add(_lineRenderer);
    }

    private void ContinueDrawing()
    {
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _deep);
        var drawingPoint = _camera.ScreenToWorldPoint(mousePosition);
        drawingPoint.z = _deep;
            
        if (_drawingArea.bounds.Contains(drawingPoint))
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, drawingPoint);
        }
    }
}