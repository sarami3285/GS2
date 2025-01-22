using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 720f; // 回転速度（度/秒）

    void Update()
    {
        // Z軸方向に回転させる
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

