using UnityEngine;
using System.Collections.Generic;


public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        // LineRendererコンポーネントを取得
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // 初期設定（必要に応じて設定を調整してください）
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 0;
    }

    // 点を追加するメソッド
    public void AddPoint(Vector3 newPoint)
    {
        points.Add(newPoint);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    // サンプルとして、Updateでマウスの位置に点を追加する
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウス位置を取得し、ワールド座標に変換
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // カメラからの距離を指定（適宜調整）
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // 点を追加
            AddPoint(worldPos);
        }
    }
}
