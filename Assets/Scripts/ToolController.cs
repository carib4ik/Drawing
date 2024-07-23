using System;
using UnityEngine;
using UnityEngine.UI;

public class ToolController : MonoBehaviour
{
    public event Action<LineRenderer> SpawnNewLine;
    
    [SerializeField] private GameObject _line;
    [SerializeField] private Button[] _buttons;
    
    private void Awake()
    {
        foreach (var button in _buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        var newLine = Instantiate(_line);
        var lineRenderer = newLine.GetComponent<LineRenderer>();
        
        var buttonColor = clickedButton.image.color;
        lineRenderer.startColor = buttonColor;
        lineRenderer.endColor = buttonColor;

        SpawnNewLine!.Invoke(lineRenderer);
    }
}
