using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float time = 0f;

    void Update()
    {
        if (transform.position.y > 4.5 || transform.position.x > 2.5 || transform.position.x < -2.5 || transform.position.y < -4.5)
        {
            Destroy(gameObject);
        }
    }

    public void Clear()
    {
        Destroy(gameObject);
    }
}
