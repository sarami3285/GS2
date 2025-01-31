using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 敵のプレハブ（3種類）
    public float spawnRate = 1.0f;    // 敵の出現間隔
    public Transform topRightLimit;   // 右上の制限オブジェクト
    public Transform bottomLeftLimit; // 左下の制限オブジェクト
    public Transform EnemyParent;     // 敵の親オブジェクト

    private float minX, maxX;
    private bool gameOver = false;     // ゲームクリアのフラグ
    public static int enemyCount = 0;  // 現在の敵の数

    public GameObject ClearScreen;
    public EnemyBullet enemyBullet;

    // GameManagerの参照
    private GameManager gameManager;

    void Start()
    {
        ClearScreen.SetActive(false);
        // GameManagerへの参照を取得
        gameManager = FindObjectOfType<GameManager>();

        // 右上・左下のX座標を取得してスポーン範囲を決定
        if (topRightLimit != null && bottomLeftLimit != null)
        {
            minX = bottomLeftLimit.position.x;
            maxX = topRightLimit.position.x;
        }
        else
        {
            Debug.LogError("制限オブジェクトが設定されていません！");
        }

        InvokeRepeating("SpawnEnemy", 1.0f, spawnRate); // 初回1秒後からスポーン開始
    }

    void Update()
    {
        Debug.Log("現在の enemyCount: " + enemyCount);
        if (gameOver)
            return;

        // 制限時間の経過をカウント
        if (gameManager != null && gameManager.timer >= 0f && gameManager.timer < 40f)
        {
            // ゲームのタイマーが0から40の間であればスポーン
            if (gameManager.timer >= 20f)
            {
                spawnRate = 2.0f; // スポーン間隔を増加
            }
        }
        else
        {
            // タイマーが40秒を超えた場合、ゲームクリア判定
            CheckGameClear();
        }
    }

    void SpawnEnemy()
    {
        if (gameManager.timer >= 40f) return; // タイマーが40秒以上の場合、敵をスポーンしない

        // 敵の出現確率に基づいて敵を決定
        GameObject enemyPrefab = GetRandomEnemyPrefab();

        // X座標のランダム決定
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, 6, 0); // Y座標は上からスポーン

        // 敵をインスタンス化
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemy.transform.SetParent(EnemyParent, true);

        // 敵が生成されたのでカウント
        enemyCount++;
    }

    // 敵の種類と出現確率を決定
    GameObject GetRandomEnemyPrefab()
    {
        float randomValue = Random.Range(0f, 1f);

        if (randomValue < 0.55f)
        {
            return enemyPrefabs[0]; // 60%で最初の敵
        }
        else if (randomValue < 0.88f)
        {
            return enemyPrefabs[1]; // 30%で2番目の敵
        }
        else if (randomValue < 0.95f)
        {
            return enemyPrefabs[2]; // 10%で3番目の敵
        }
        else
        {
            return enemyPrefabs[3];
        }
    }

    // ゲームクリアの判定
    void CheckGameClear()
    {
        if (enemyCount == 0)
        {
            enemyBullet.Clear();
            ClearScreen.SetActive(true);
            Debug.Log("ゲームクリア!");
            gameOver = true;
        }
    }

    // Spawnerのリセット処理
    public void ResetSpawner()
    {
        enemyCount = 0;
        gameOver = false;
        spawnRate = 1.0f; // スポーン間隔をリセット
    }
}



