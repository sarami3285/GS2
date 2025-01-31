using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.2f;
    public Transform bulletParent; // �e�̐e�I�u�W�F�N�g
    public Transform topRightLimit; // �E��̐����I�u�W�F�N�g
    public Transform bottomLeftLimit; // �����̐����I�u�W�F�N�g

    public AudioSource audioSource;
    public AudioClip ShotSE;

    private float nextFire = 0f;
    private float minX, maxX, minY, maxY; // ��ʓ��̈ړ��͈�

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
            Debug.LogError("�ړ��͈͂̃I�u�W�F�N�g���ݒ肳��Ă��܂���I");
        }
    }

    void Update()
    {
        // �ړ�
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, moveY, 0) * speed * Time.deltaTime;
        transform.position += move;

        // �ʒu����
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY),
            transform.position.z
        );

        // �U��
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.transform.SetParent(bulletParent, true); // �e��ݒ�
            audioSource.PlayOneShot(ShotSE);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")|| other.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject); // �G���j��
        }
    }
}
