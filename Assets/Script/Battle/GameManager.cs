using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 0f;          // ゲームの経過時間
    private float maxTime = 40f;      // 制限時間（40秒）
    public Spawner spawner;           // Spawnerへの参照
    public PlayerController player;

    public GameObject CoinExchange;

    void Update()
    {
        // タイマーの経過を更新
        if (timer < maxTime)
        {
            timer += Time.deltaTime;
        }

        // タイマーが最大時間を超えた場合、ゲーム終了
        if (timer >= maxTime)
        {
            timer = maxTime; // 最大時間で固定
        }
    }

    // リセット処理
    public void Reset()
    {
        timer = 0f;  // タイマーをリセット
        spawner.ResetSpawner(); // Spawnerのリセット処理を呼び出す
        player.ResetHP();
    }

    public void ActivateCoinExchange()
    {
        CoinExchange.SetActive(true);
    }
}
