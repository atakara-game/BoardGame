using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int Position; // タイルの位置

    [SerializeField]
    private Renderer _tileRenderer;

    [SerializeField]
    private Color _originalColor; // 元の色を保存

    void Start()
    {
        _tileRenderer = GetComponent<Renderer>();
        _originalColor = _tileRenderer.material.color; // 元の色を保存
    }

    public void ChangeColor(Color newColor)
    {
        _tileRenderer.material.color = newColor;
    }

    public void ResetColor()
    {
        _tileRenderer.material.color = _originalColor;
    }

}
