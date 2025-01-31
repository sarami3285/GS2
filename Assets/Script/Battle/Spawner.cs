using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // �G�̃v���n�u�i3��ށj
    public float spawnRate = 1.0f;    // �G�̏o���Ԋu
    public Transform topRightLimit;   // �E��̐����I�u�W�F�N�g
    public Transform bottomLeftLimit; // �����̐����I�u�W�F�N�g
    public Transform EnemyParent;     // �G�̐e�I�u�W�F�N�g

    private float minX, maxX;
    private bool gameOver = false;     // �Q�[���N���A�̃t���O
    public static int enemyCount = 0;  // ���݂̓G�̐�

    public GameObject ClearScreen;
    public EnemyBullet enemyBullet;

    // GameManager�̎Q��
    private GameManager gameManager;

    void Start()
    {
        ClearScreen.SetActive(false);
        // GameManager�ւ̎Q�Ƃ��擾
        gameManager = FindObjectOfType<GameManager>();

        // �E��E������X���W���擾���ăX�|�[���͈͂�����
        if (topRightLimit != null && bottomLeftLimit != null)
        {
            minX = bottomLeftLimit.position.x;
            maxX = topRightLimit.position.x;
        }
        else
        {
            Debug.LogError("�����I�u�W�F�N�g���ݒ肳��Ă��܂���I");
        }

        InvokeRepeating("SpawnEnemy", 1.0f, spawnRate); // ����1�b�ォ��X�|�[���J�n
    }

    void Update()
    {
        Debug.Log("���݂� enemyCount: " + enemyCount);
        if (gameOver)
            return;

        // �������Ԃ̌o�߂��J�E���g
        if (gameManager != null && gameManager.timer >= 0f && gameManager.timer < 40f)
        {
            // �Q�[���̃^�C�}�[��0����40�̊Ԃł���΃X�|�[��
            if (gameManager.timer >= 20f)
            {
                spawnRate = 2.0f; // �X�|�[���Ԋu�𑝉�
            }
        }
        else
        {
            // �^�C�}�[��40�b�𒴂����ꍇ�A�Q�[���N���A����
            CheckGameClear();
        }
    }

    void SpawnEnemy()
    {
        if (gameManager.timer >= 40f) return; // �^�C�}�[��40�b�ȏ�̏ꍇ�A�G���X�|�[�����Ȃ�

        // �G�̏o���m���Ɋ�Â��ēG������
        GameObject enemyPrefab = GetRandomEnemyPrefab();

        // X���W�̃����_������
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 6, 0); // Y���W�͏ォ��X�|�[��

        // �G���C���X�^���X��
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.SetParent(EnemyParent, true);

        // �G���������ꂽ�̂ŃJ�E���g
        enemyCount++;
    }

    // �G�̎�ނƏo���m��������
    GameObject GetRandomEnemyPrefab()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue < 0.55f)
        {
            return enemyPrefabs[0]; // 60%�ōŏ��̓G
        }
        else if (randomValue < 0.88f)
        {
            return enemyPrefabs[1]; // 30%��2�Ԗڂ̓G
        }
        else if (randomValue < 0.95f)
        {
            return enemyPrefabs[2]; // 10%��3�Ԗڂ̓G
        }
        else
        {
            return enemyPrefabs[3];
        }
    }

    // �Q�[���N���A�̔���
    void CheckGameClear()
    {
        if (enemyCount == 0)
        {
            enemyBullet.Clear();
            ClearScreen.SetActive(true);
            Debug.Log("�Q�[���N���A!");
            gameOver = true;
        }
    }

    // Spawner�̃��Z�b�g����
    public void ResetSpawner()
    {
        enemyCount = 0;
        gameOver = false;
        spawnRate = 1.0f; // �X�|�[���Ԋu�����Z�b�g
    }
}



