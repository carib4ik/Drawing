using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    [SerializeField] private Collider _drawingArea;
    [SerializeField] private float _deep;

    private LineRenderer _lineRenderer;
    private Camera _camera;
    private List<LineRenderer> _lines;

    private void Awake()
    {
        _camera = Camera.main;
        _lines = new List<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _lineRenderer != null)
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

        if (Input.GetMouseButtonUp(0) && _lineRenderer != null)
        {
            
        }
    }

    public void AddLine(LineRenderer lineRenderer)
    {
        _lineRenderer = lineRenderer;
        _lineRenderer.positionCount = 0;
        _lines.Add(lineRenderer);
    }

    public void EraseEverything()
    {
        foreach (var lineRenderer in _lines)
        {
            Destroy(lineRenderer.gameObject);
        }
        
        _lines.Clear();
    }
}