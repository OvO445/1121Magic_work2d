using UnityEngine;

public class AutoMoveforX : MonoBehaviour
{
    [SerializeField] private float speed = 2f;  // 移動速度
    [SerializeField] private float range = 3f;  // 移動範圍
    private Vector3 startPosition;              // 初始位置

    void Start()
    {
        startPosition = transform.position;    // 記錄初始位置
    }

    void Update()
    {
        // 使用Sin函數實現平滑的來回移動
        float offset = Mathf.Sin(Time.time * speed) * range;
        Vector3 newPosition = startPosition;
        newPosition.x += offset;
        transform.position = newPosition;
    }
}