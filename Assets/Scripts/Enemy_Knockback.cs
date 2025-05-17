using System.Collections;
using UnityEngine;

public class Enemy_Knockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private Enemy_Movement enemy_Movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy_Movement = GetComponent<Enemy_Movement>();
    }
    public void Knockback(Transform playerTrans, float knockbackForce, float stunTime, float knockbackTime)
    {
        enemy_Movement.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(stunTime, knockbackTime));
        Vector2 direction = (transform.position - playerTrans.position).normalized;
        rb.linearVelocity = knockbackForce * direction;

    }

    IEnumerator StunTimer(float stunTime, float knockbackTime)
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemy_Movement.ChangeState(EnemyState.Idle);
    }
}
