using UnityEngine;
using UnityEngine.UI;

public class StaminaRecover : MonoBehaviour
{
    public Slider staminaSlider;         // �X�^�~�i�X���C�_�[
    public GameObject targetObject;     // �L��������I�u�W�F�N�g
    public float countdownTime = 60f;   // 60�b�J�E���g
    private float timer;                // �^�C�}�[�p�ϐ�
    private bool isCounting = false;    // �J�E���g�����ǂ���
    private bool hasActivated = false;  // targetObject ����x�����L�������邽�߂̃t���O

    public Text sliderValueText; // �X���C�_�[�l�̕\���p (Text�ɕύX)
    public Text timerText;       // �^�C�}�[�̎c�莞�ԕ\���p (Text�ɕύX)

    private void Start()
    {
        timer = countdownTime;
    }

    private void Update()
    {
        // �X���C�_�[�̌��݂̒l���p�[�Z���e�[�W�Ōv�Z���ĕ\��
        int sliderPercentage = Mathf.FloorToInt((staminaSlider.value / staminaSlider.maxValue) * 100f);
        sliderValueText.text = $"{sliderPercentage}";

        if (isCounting)
        {
            // �^�C�}�[�̎c�莞�Ԃ�b���ŕ\��
            timerText.text = $"�񕜂܂Ŏc��: {Mathf.Ceil(timer)}�b";
        }

        // �X�^�~�i���ő�̏ꍇ�A�J�E���g���~
        if (staminaSlider.value >= staminaSlider.maxValue)
        {
            isCounting = false;
            timer = countdownTime; // �^�C�}�[�����Z�b�g
            hasActivated = false;  // �X�^�~�i���ő�ɂȂ����烊�Z�b�g
            return;
        }

        // �X�^�~�i��Max�łȂ��ꍇ�A�J�E���g���J�n
        if (!isCounting && staminaSlider.value < staminaSlider.maxValue)
        {
            isCounting = true;
        }

        // �J�E���g����
        if (isCounting)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f && !hasActivated)
            {
                timer = 0;
                targetObject.SetActive(true); // �I�u�W�F�N�g��L����
                hasActivated = true;         // ��x�����L��������悤�Ƀt���O��ݒ�
            }
        }
    }

    public void Complete()
    {
        timer = countdownTime;
        hasActivated = false; // �����I�ɍēx�L�����ł���悤�Ƀ��Z�b�g
    }
}




