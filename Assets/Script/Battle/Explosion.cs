using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator animator;
    public Transform childObject;  // 子オブジェクト（敵）のTransform
    public float speed = 500f;
    bool Move = true;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Animatorを自動的に取得
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
        // 爆発アニメーション開始
        animator.SetTrigger("Explosion");
    }

    public void AnimEnd()
    {
        // 爆発アニメーション終了
        animator.SetTrigger("AllEnd");
        Spawner.enemyCount--;
        Destroy(this.gameObject);  // 親オブジェクトを削除
    }

    // 子オブジェクトを親の位置に追従させる
    public void SetChildPositionZero()
    {
        if (childObject != null)
        {
            childObject.localPosition = Vector3.zero;
        }
    }
}


