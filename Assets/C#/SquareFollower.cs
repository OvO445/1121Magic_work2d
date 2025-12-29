using UnityEngine;

public class SquareFollower : MonoBehaviour
{
    [Header("跟隨設定")]
    public SquareMovement targetToFollow;  // 要跟隨的目標物件
    public float followDelay = 1f;        // 跟隨延遲時間
    public float moveSpeed = 5f;          // 移動速度

    private Vector3 targetPosition;       // 目標位置
    private float timeSinceStart = 0f;    // 開始後經過的時間

    void Start()
    {
        if (targetToFollow == null)
        {
            Debug.LogError("請指定要跟隨的目標物件！");
            enabled = false;
            return;
        }
        // 初始位置設定為目標物件的起始位置
        transform.position = targetToFollow.transform.position;
    }

    void FixedUpdate()
    {
        // 更新經過的時間
        timeSinceStart += Time.deltaTime;

        if (timeSinceStart >= followDelay)
        {
            // 計算延遲後的目標位置
            targetPosition = targetToFollow.transform.position;
            
            // 計算當前位置到目標位置的方向
            Vector3 direction = (targetPosition - transform.position).normalized;
            
            // 移動物件
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}