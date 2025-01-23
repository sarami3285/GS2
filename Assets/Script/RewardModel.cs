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
        // �q�I�u�W�F�N�g��Image��Text���擾
        childImages = GetComponentsInChildren<Image>();
        childTexts = GetComponentsInChildren<Text>();

        // ���̐F��ۑ�
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

        // �R���[�`���J�n
        StartCoroutine(FadeOutAndDestroyChildren());
    }

    private System.Collections.IEnumerator FadeOutAndDestroyChildren()
    {
        // 3�b�҂�
        yield return new WaitForSeconds(1.5f);

        // 3�b�����ē����x�����炷
        float duration = 2f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);

            // Image�̓����x��ύX
            SetImageAlpha(alpha);

            // Text�̓����x��ύX
            SetTextAlpha(alpha);

            yield return null;
        }

        // �q�I�u�W�F�N�g���ʂɔj��
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



