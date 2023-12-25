using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField]
    public Color highlightedTileColor = Color.red; // ハイライトされたタイルの色
    private Tile currentTile;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Tile hitTile = hit.collider.GetComponent<Tile>();
            if (hitTile != null && currentTile != hitTile)
            {
                // 前のタイルの色をリセット
                if (currentTile != null)
                {
                    currentTile.ResetColor();
                }

                // 新しいタイルの色を変更
                currentTile = hitTile;
                currentTile.ChangeColor(highlightedTileColor);
            }
        }
        else if (currentTile != null) // RayCastがタイルから外れた場合
        {
            // タイルの色をリセット
            currentTile.ResetColor();
            currentTile = null;
        }
    }
}
