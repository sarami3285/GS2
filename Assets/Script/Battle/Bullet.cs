using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    void Update()
    {
        transform.Translate(Vector3.up * 10f * Time.deltaTime);
        if (transform.position.y > 4.5|| transform.position.x > 2.5|| transform.position.x < -2.5|| transform.position.y < -4.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

