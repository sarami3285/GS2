using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixerをInspectorでアタッチ
    public Slider bgmSlider;      // BGM音量用スライダー
    public Slider seSlider;       // SE音量用スライダー

    private void Start()
    {
        // スライダーの初期値を設定（例: 音量を0.5に設定）
        bgmSlider.value = 0.7f;
        seSlider.value = 0.7f;

        // スライダーのリスナーを設定
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);
    }

    // BGM音量の調整
    public void SetBGMVolume(float volume)
    {
        if (volume <= 0.01f) // スライダー値がほぼ0の場合
        {
            audioMixer.SetFloat("BGM", -80f); // 音量を完全にミュート
        }
        else
        {
            audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20); // dB変換
        }
    }

    // SE音量の調整
    public void SetSEVolume(float volume)
    {
        if (volume <= 0.01f) // スライダー値がほぼ0の場合
        {
            audioMixer.SetFloat("SE", -80f); // 音量を完全にミュート
        }
        else
        {
            audioMixer.SetFloat("SE", Mathf.Log10(volume) * 20); // dB変換
        }
    }
}

