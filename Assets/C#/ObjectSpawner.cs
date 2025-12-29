using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("生成設定")]
    public GameObject prefabToSpawn;    // 要生成的預製體
    public float spawnInterval = 2f;    // 生成間隔時間（秒）
    public int maxSpawnCount = 5;       // 最大生成數量
    public Vector3 spawnOffset = Vector3.zero;  // 生成位置偏移

    private float nextSpawnTime = 0f;   // 下次生成時間
    private int currentSpawnCount = 0;   // 當前已生成數量

    void Start()
    {
        if (prefabToSpawn == null)
        {
            Debug.LogError("請指定要生成的預製體！");
            enabled = false;
            return;
        }
    }

    void FixedUpdate()
    {
        // 檢查是否達到最大生成數量
        if (currentSpawnCount >= maxSpawnCount)
        {
            return;
        }

        // 檢查是否到達生成時間
        if (Time.time >= nextSpawnTime)
        {
            // 在當前位置生成物件
            Vector3 spawnPosition = transform.position + spawnOffset;
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // 更新計數和下次生成時間
            currentSpawnCount++;
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}