using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;

        if (time > 10f)
        {
            Destroy(gameObject);
        }
    }

    public void Clear()
    {
        Destroy(gameObject);
    }
}
