using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator animator;
    public Transform childObject;
    public float speed = 500f;
    bool Move = true;
    public int Attack;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
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
        animator.SetTrigger("Explosion");
    }

    public void AnimEnd()
    {
        animator.SetTrigger("AllEnd");
        Spawner.enemyCount--;
        Destroy(this.gameObject);
    }

    public void SetChildPositionZero()
    {
        if (childObject != null)
        {
            childObject.localPosition = Vector3.zero;
        }
    }
}


