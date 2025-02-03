using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int HP;
    public Explosion explosionManager;  // 親オブジェクト（ExplosionManager）
    public Bullet bullet;
    private SpriteRenderer spriteRenderer;

    public GameObject Bullet;
    public Transform Player;
    public float BulletSpeed;

    public bool Enemy2;
    public bool Enemy3;

    public int damage;

    void Start()
    {
        HP = 1 + Spawner.level / 4;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (Enemy2)
        {
            HP = 2 + Spawner.level / 2;
            InvokeRepeating(nameof(Enemy2AI), 0f, 1.8f); // 2秒ごとに発射
        }

        if (Enemy3)
        {
            HP = 8 + Spawner.level * 2; ;
            InvokeRepeating(nameof(Enemy3AI), 0f, 2.6f); // 3秒ごとに発射
        }
    }

    void Update()
    {
        // 画面外で削除
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Bullet"))
        {
            HP -= bullet.damage;
            if (HP == 0)
            {
                // 爆発エフェクトを開始
                explosionManager.AnimStart();

                // 子オブジェクトの位置を親オブジェクトの中心に設定
                explosionManager.SetChildPositionZero();

                // 子オブジェクト（敵）を削除
                Destroy(gameObject);
            }
        }
    }

    void Enemy2AI()
    {
        if (Player == null) return;

        // プレイヤーの方向を取得
        Vector2 direction = (Player.position - transform.position).normalized;

        // 弾を発射
        FireBullet(direction);
    }

    void Enemy3AI()
    {
        if (Player == null) return;

        // プレイヤーの方向を取得
        Vector2 direction = (Player.position - transform.position).normalized;

        // 3方向に弾を発射（正面, +15度, -15度）
        FireBullet(direction);
        FireBullet(Quaternion.Euler(0, 0, 50) * direction);
        FireBullet(Quaternion.Euler(0, 0, 100) * direction);
        FireBullet(Quaternion.Euler(0, 0, 150) * direction);
        FireBullet(Quaternion.Euler(0, 0, -50) * direction);
        FireBullet(Quaternion.Euler(0, 0, -100) * direction);
        FireBullet(Quaternion.Euler(0, 0, -150) * direction);
    }

    void FireBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed; // BulletSpeedを適用
    }
}

