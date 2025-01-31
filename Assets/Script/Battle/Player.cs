using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;
    public Transform bulletParent; // 弾の親オブジェクト
    public Transform topRightLimit; // 右上の制限オブジェクト
    public Transform bottomLeftLimit; // 左下の制限オブジェクト

    public AudioSource audioSource;
    public AudioClip ShotSE;

    private float nextFire = 0f;
    private float minX, maxX, minY, maxY; // 画面内の移動範囲

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
        // 移動
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.position += move;

        // 位置制限
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        // 攻撃
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.transform.SetParent(bulletParent, true); // 親を設定
            audioSource.PlayOneShot(ShotSE);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")|| other.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject); // 敵も破壊
        }
    }
}
