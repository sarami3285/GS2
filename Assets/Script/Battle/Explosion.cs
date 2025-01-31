using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator animator;
    public Transform childObject;  // �q�I�u�W�F�N�g�i�G�j��Transform
    public float speed = 500f;
    bool Move = true;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Animator�������I�Ɏ擾
        }
    }

    void Update()
    {
        if (transform.position.y < -5)
        {
            Spawner.enemyCount--;
            Destroy(gameObject);
        }

        if (Move)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }

    public void AnimStart()
    {
        Move = false;
        // �����A�j���[�V�����J�n
        animator.SetTrigger("Explosion");
    }

    public void AnimEnd()
    {
        // �����A�j���[�V�����I��
        animator.SetTrigger("AllEnd");
        Spawner.enemyCount--;
        Destroy(this.gameObject);  // �e�I�u�W�F�N�g���폜
    }

    // �q�I�u�W�F�N�g��e�̈ʒu�ɒǏ]������
    public void SetChildPositionZero()
    {
        if (childObject != null)
        {
            childObject.localPosition = Vector3.zero;
        }
    }
}


