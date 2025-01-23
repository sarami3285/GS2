using UnityEngine;
using UnityEngine.UI;

public class FadeAndDestroyChildren : MonoBehaviour
{
    private Image[] childImages;
    private Text[] childTexts;
    private Color[] originalImageColors;
    private Color[] originalTextColors;

    private void OnEnable()
    {
        // 子オブジェクトのImageとTextを取得
        childImages = GetComponentsInChildren<Image>();
        childTexts = GetComponentsInChildren<Text>();

        // 元の色を保存
        originalImageColors = new Color[childImages.Length];
        for (int i = 0; i < childImages.Length; i++)
        {
            originalImageColors[i] = childImages[i].color;
        }

        originalTextColors = new Color[childTexts.Length];
        for (int i = 0; i < childTexts.Length; i++)
        {
            originalTextColors[i] = childTexts[i].color;
        }

        // コルーチン開始
        StartCoroutine(FadeOutAndDestroyChildren());
    }

    private System.Collections.IEnumerator FadeOutAndDestroyChildren()
    {
        // 3秒待つ
        yield return new WaitForSeconds(1.5f);

        // 3秒かけて透明度を減らす
        float duration = 2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);

            // Imageの透明度を変更
            SetImageAlpha(alpha);

            // Textの透明度を変更
            SetTextAlpha(alpha);

            yield return null;
        }

        // 子オブジェクトを個別に破棄
        //DestroyChildren();
    }

    private void SetImageAlpha(float alpha)
    {
        for (int i = 0; i < childImages.Length; i++)
        {
            if (childImages[i] != null)
            {
                Color newColor = originalImageColors[i];
                newColor.a = alpha;
                childImages[i].color = newColor;
            }
        }
    }

    private void SetTextAlpha(float alpha)
    {
        for (int i = 0; i < childTexts.Length; i++)
        {
            if (childTexts[i] != null)
            {
                Color newColor = originalTextColors[i];
                newColor.a = alpha;
                childTexts[i].color = newColor;
            }
        }
    }

    private void DestroyChildren()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void UIMove()
    {
        this.gameObject.SetActive(false);
    }
}



