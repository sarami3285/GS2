using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 720f; // ‰ñ“]‘¬“xi“x/•bj

    void Update()
    {
        // Z²•ûŒü‚É‰ñ“]‚³‚¹‚é
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

