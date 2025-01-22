using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixer��Inspector�ŃA�^�b�`
    public Slider bgmSlider;      // BGM���ʗp�X���C�_�[
    public Slider seSlider;       // SE���ʗp�X���C�_�[

    private void Start()
    {
        // �X���C�_�[�̏����l��ݒ�i��: ���ʂ�0.5�ɐݒ�j
        bgmSlider.value = 0.7f;
        seSlider.value = 0.7f;

        // �X���C�_�[�̃��X�i�[��ݒ�
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);
    }

    // BGM���ʂ̒���
    public void SetBGMVolume(float volume)
    {
        if (volume <= 0.01f) // �X���C�_�[�l���ق�0�̏ꍇ
        {
            audioMixer.SetFloat("BGM", -80f); // ���ʂ����S�Ƀ~���[�g
        }
        else
        {
            audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20); // dB�ϊ�
        }
    }

    // SE���ʂ̒���
    public void SetSEVolume(float volume)
    {
        if (volume <= 0.01f) // �X���C�_�[�l���ق�0�̏ꍇ
        {
            audioMixer.SetFloat("SE", -80f); // ���ʂ����S�Ƀ~���[�g
        }
        else
        {
            audioMixer.SetFloat("SE", Mathf.Log10(volume) * 20); // dB�ϊ�
        }
    }
}

