using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public Transform bulletParent;
    public Transform topRightLimit;
    public Transform bottomLeftLimit;

    public SkillData currentSkill; // スキルのデータ

    public AudioSource audioSource;
    public AudioClip ShotSE;

    private float nextFire = 0f;
    private float minX, maxX, minY, maxY;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (topRightLimit != null && bottomLeftLimit != null)
        {
            minX = bottomLeftLimit.position.x;
            minY = bottomLeftLimit.position.y;
            maxX = topRightLimit.position.x;
            maxY = topRightLimit.position.y;
        }
        else
        {
            Debug.LogError("移動範囲のオブジェクトが設定されていません！");
        }
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.position += move;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            audioSource.PlayOneShot(ShotSE);
            nextFire = Time.time + currentSkill.fireRate;

            if (currentSkill.isBurstType)
            {
                for (int i = 0; i < currentSkill.bulletCount; i++)
                {
                    float offsetX = (i - (currentSkill.bulletCount - 1) / 2.0f) * 0.5f;
                    Vector3 spawnPosition = bulletSpawnPoint.position + new Vector3(offsetX, 0, 0);
                    GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
                    bullet.transform.SetParent(bulletParent, true);
                }
            }
            else if (currentSkill.isSpreadType)
            {
                GameObject centerBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                centerBullet.transform.SetParent(bulletParent, true);

                int spreadLevel = (currentSkill.bulletCount - 1) / 2;
                for (int i = 1; i <= spreadLevel; i++)
                {
                    float angle = i * 10;
                    Quaternion rightRotation = Quaternion.Euler(0, 0, -angle);
                    GameObject rightBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, rightRotation);
                    rightBullet.transform.SetParent(bulletParent, true);
                    Quaternion leftRotation = Quaternion.Euler(0, 0, angle);
                    GameObject leftBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, leftRotation);
                    leftBullet.transform.SetParent(bulletParent, true);
                }
            }
            else
            {
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
                bullet.transform.SetParent(bulletParent, true);
            }
        }
    }

    public void ChangeSkill(SkillData newSkill)
    {
        currentSkill = newSkill;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
        }
    }
}