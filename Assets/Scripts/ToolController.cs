using System;
using UnityEngine;
using UnityEngine.UI;

public class ToolController : MonoBehaviour
{
    public event Action<Color> SpawnNewLine;
    
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Button _sponge;
    
    private void Awake()
    {
        foreach (var button in _buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button clickedButton)
    {
        var buttonColor = clickedButton.image.color;
        SpawnNewLine!.Invoke(buttonColor);
    }
}
