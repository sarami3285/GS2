using UnityEngine;

public class CursolSound : MonoBehaviour
{
    public AudioClip hoverClip; // ���ʉ���Inspector�Őݒ�
    private AudioSource audioSource;

    private void Start()
    {
        // AudioSource���擾�i�܂��͂��̃X�N���v�g���A�^�b�`����Ă���I�u�W�F�N�g�ɒǉ��j
        audioSource = FindObjectOfType<AudioSource>();
    }

    // �J�[�\�����{�^���ɏ�����Ƃ��ɌĂяo�����
    public void PlayHoverSound()
    {
        if (audioSource != null && hoverClip != null)
        {
            audioSource.PlayOneShot(hoverClip);
        }
    }
}
