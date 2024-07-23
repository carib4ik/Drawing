using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Draw _drawer;
    [SerializeField] private ToolController _toolController;

    private void Awake()
    {
        _toolController.SpawnNewLine += _drawer.SetColor;
    }
}
