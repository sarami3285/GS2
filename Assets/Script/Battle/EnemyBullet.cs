using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y > 4.5 || transform.position.x > 2.5 || transform.position.x < -2.5 || transform.position.y < -4.5)
        {
            Destroy(gameObject);
        }
    }
}
