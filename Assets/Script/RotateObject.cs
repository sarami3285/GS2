using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 720f; // ��]���x�i�x/�b�j

    void Update()
    {
        // Z�������ɉ�]������
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

