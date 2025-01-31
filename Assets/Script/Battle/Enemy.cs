using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 3;
    public Explosion explosionManager;  // �e�I�u�W�F�N�g�iExplosionManager�j
    private SpriteRenderer spriteRenderer;

    public GameObject Bullet;
    public Transform Player;
    public float BulletSpeed;

    public bool Enemy2;
    public bool Enemy3;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (Enemy2)
        {
            InvokeRepeating(nameof(Enemy2AI), 1f, 2f); // 2�b���Ƃɔ���
        }

        if (Enemy3)
        {
            InvokeRepeating(nameof(Enemy3AI), 1f, 3f); // 3�b���Ƃɔ���
        }
    }

    void Update()
    {
        // ��ʊO�ō폜
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
            HP--;
            if (HP == 0)
            {

                // �����G�t�F�N�g���J�n
                explosionManager.AnimStart();

                // �q�I�u�W�F�N�g�̈ʒu��e�I�u�W�F�N�g�̒��S�ɐݒ�
                explosionManager.SetChildPositionZero();

                // �q�I�u�W�F�N�g�i�G�j���폜
                Destroy(gameObject);
            }
        }
    }

    void Enemy2AI()
    {
        if (Player == null) return;

        // �v���C���[�̕������擾
        Vector2 direction = (Player.position - transform.position).normalized;

        // �e�𔭎�
        FireBullet(direction);
    }

    void Enemy3AI()
    {
        if (Player == null) return;

        // �v���C���[�̕������擾
        Vector2 direction = (Player.position - transform.position).normalized;

        // 3�����ɒe�𔭎ˁi����, +15�x, -15�x�j
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
        bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed; // BulletSpeed��K�p
    }
}

