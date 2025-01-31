using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject CoinExchange;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.down * 3f * Time.deltaTime);

        if (transform.position.y < -5)
        {
            Spawner.enemyCount--;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.ActivateCoinExchange(); // CoinManager�ɒʒm����CoinExchange��L����
            }
            Spawner.enemyCount--;
            Destroy(this.gameObject); // �R�C��������
        }
    }
}

