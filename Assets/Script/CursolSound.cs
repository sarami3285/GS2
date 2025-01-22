using UnityEngine;

public class CursolSound : MonoBehaviour
{
    public AudioClip hoverClip; // 効果音をInspectorで設定
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSourceを取得（またはこのスクリプトがアタッチされているオブジェクトに追加）
        audioSource = FindObjectOfType<AudioSource>();
    }

    // カーソルがボタンに乗ったときに呼び出される
    public void PlayHoverSound()
    {
        if (audioSource != null && hoverClip != null)
        {
            audioSource.PlayOneShot(hoverClip);
        }
    }
}
