using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 5f;  // 移動速度
    public float squareSize = 2f;  // 正方形邊長

    private Vector3 startPosition;  // 起始位置
    private int currentPoint = 0;   // 當前目標點索引
    private Vector3[] points;       // 正方形的四個頂點

    void Start()
    {
        startPosition = transform.position;
        // 初始化四個頂點位置
        points = new Vector3[4]
        {
            startPosition + Vector3.right * squareSize,                    // 右
            startPosition + new Vector3(squareSize, squareSize, 0),        // 右上
            startPosition + Vector3.up * squareSize,                       // 上
            startPosition                                                  // 回到起點
        };
    }

    void FixedUpdate()
    {
        // 計算當前位置到目標點的方向
        Vector3 direction = (points[currentPoint] - transform.position).normalized;
        
        // 移動物件
        transform.position += direction * moveSpeed * Time.deltaTime;

        // 檢查是否到達目標點
        if (Vector3.Distance(transform.position, points[currentPoint]) < 0.1f)
        {
            // 更新到下一個目標點
            currentPoint = (currentPoint + 1) % points.Length;
            // 精確設置位置，避免誤差累積
            transform.position = points[currentPoint == 0 ? points.Length - 1 : currentPoint - 1];
        }
    }

    // 在Scene視圖中繪製路徑
    void OnDrawGizmos()
    {
        if (Application.isPlaying && points != null)
        {
            Gizmos.color = Color.yellow;
            for (int i = 0; i < points.Length; i++)
            {
                Gizmos.DrawLine(points[i], points[(i + 1) % points.Length]);
            }
        }
    }
}