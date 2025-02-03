using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 0f;          // �Q�[���̌o�ߎ���
    private float maxTime = 40f;      // �������ԁi40�b�j
    public Spawner spawner;           // Spawner�ւ̎Q��
    public PlayerController player;

    public GameObject CoinExchange;

    void Update()
    {
        // �^�C�}�[�̌o�߂��X�V
        if (timer < maxTime)
        {
            timer += Time.deltaTime;
        }

        // �^�C�}�[���ő厞�Ԃ𒴂����ꍇ�A�Q�[���I��
        if (timer >= maxTime)
        {
            timer = maxTime; // �ő厞�ԂŌŒ�
        }
    }

    // ���Z�b�g����
    public void Reset()
    {
        timer = 0f;  // �^�C�}�[�����Z�b�g
        spawner.ResetSpawner(); // Spawner�̃��Z�b�g�������Ăяo��
        player.ResetHP();
    }

    public void ActivateCoinExchange()
    {
        CoinExchange.SetActive(true);
    }
}
