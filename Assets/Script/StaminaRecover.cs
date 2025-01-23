using UnityEngine;
using UnityEngine.UI;

public class StaminaRecover : MonoBehaviour
{
    public Slider staminaSlider;         // スタミナスライダー
    public GameObject targetObject;     // 有効化するオブジェクト
    public float countdownTime = 60f;   // 60秒カウント
    private float timer;                // タイマー用変数
    private bool isCounting = false;    // カウント中かどうか
    private bool hasActivated = false;  // targetObject を一度だけ有効化するためのフラグ

    public Text sliderValueText; // スライダー値の表示用 (Textに変更)
    public Text timerText;       // タイマーの残り時間表示用 (Textに変更)

    private void Start()
    {
        timer = countdownTime;
    }

    private void Update()
    {
        // スライダーの現在の値をパーセンテージで計算して表示
        int sliderPercentage = Mathf.FloorToInt((staminaSlider.value / staminaSlider.maxValue) * 100f);
        sliderValueText.text = $"{sliderPercentage}";

        if (isCounting)
        {
            // タイマーの残り時間を秒数で表示
            timerText.text = $"回復まで残り: {Mathf.Ceil(timer)}秒";
        }

        // スタミナが最大の場合、カウントを停止
        if (staminaSlider.value >= staminaSlider.maxValue)
        {
            isCounting = false;
            timer = countdownTime; // タイマーをリセット
            hasActivated = false;  // スタミナが最大になったらリセット
            return;
        }

        // スタミナがMaxでない場合、カウントを開始
        if (!isCounting && staminaSlider.value < staminaSlider.maxValue)
        {
            isCounting = true;
        }

        // カウント処理
        if (isCounting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f && !hasActivated)
            {
                timer = 0;
                targetObject.SetActive(true); // オブジェクトを有効化
                hasActivated = true;         // 一度だけ有効化するようにフラグを設定
            }
        }
    }

    public void Complete()
    {
        timer = countdownTime;
        hasActivated = false; // 強制的に再度有効化できるようにリセット
    }
}




