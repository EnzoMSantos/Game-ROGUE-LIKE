using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float baseAttackForce = 8f;
    public float attackForceIncreaseFactor = 1.2f;
    public float attackCooldown = 5f;
    public float attackDistance = 1f;

    private float currentAttackForce;
    private Transform player;
    private Rigidbody2D rb;
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        currentAttackForce = baseAttackForce;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (!canAttack)
        {
            // Pausa após o ataque
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0f)
            {
                canAttack = true;
                attackCooldown = 5f; // Reinicie o cooldown do ataque
                rb.velocity = Vector2.zero; // Pare o movimento após a pausa
            }
        }
        else
        {
            // Movimento em direção ao jogador
            if (distanceToPlayer > attackDistance)
            {
                Vector2 moveDirection = (player.position - transform.position).normalized;
                rb.velocity = moveDirection * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;

                // Ataca o jogador
                Attack();
            }
        }
    }

    private void Attack()
    {
        Vector2 attackDirection = (player.position - transform.position).normalized;
        player.GetComponent<CharacterController>().TakeKnockback(attackDirection * currentAttackForce);

        canAttack = false;
        Invoke(nameof(ResetAttackCooldown), attackCooldown);
    }

    private void ResetAttackCooldown()
    {
        canAttack = true;
        IncreaseAttackForce();
    }

    private void IncreaseAttackForce()
    {
        currentAttackForce *= attackForceIncreaseFactor;
    }
}
