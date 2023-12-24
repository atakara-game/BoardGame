using UnityEngine;

public class StageObject : MonoBehaviour
{
    [SerializeField]
    public GameObject tilePrefab; // タイルのPrefab

    [SerializeField]
    public int width = 5; // 幅

    [SerializeField]
    public int height = 5; // 高さ

    [SerializeField]
    private Color color1 = Color.white; // 一つ目の色

    [SerializeField]
    private Color color2 = Color.black; // 二つ目の色

    void Start()
    {
        GenerateTiles();
    }

    void GenerateTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // タイルのインスタンスを生成
                GameObject newTile = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                newTile.transform.parent = this.transform; // 生成されたタイルをこのオブジェクトの子にする

                // 市松模様の色を適用
                Renderer tileRenderer = newTile.GetComponent<Renderer>();
                if (tileRenderer != null)
                {
                    tileRenderer.material.color = (x + y) % 2 == 0 ? color1 : color2;
                }
            }
        }
    }
}
