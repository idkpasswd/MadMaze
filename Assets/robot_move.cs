using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_move : MonoBehaviour
{
    public float amplitude = 1.0f; // 振幅，控制前后移动的最大距离
    public float speed = 1.0f; // 速度，控制移动的快慢
    private Vector3 startPosition; // 初始位置

    // Start is called before the first frame update
    void Start()
    {
        // 记录起始位置
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 计算新的z位置
        float zPosition = amplitude * Mathf.Sin(Time.time * speed);

        // 更新物体的位置
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + zPosition);
    }
}
