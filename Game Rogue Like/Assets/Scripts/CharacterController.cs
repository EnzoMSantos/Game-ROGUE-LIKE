using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float knockbackForce = 10f;
    public float knockbackDuration = 0.5f;
    public float recoveryTime = 1f;

    private Rigidbody2D rb;
    public float baseKnockbackForce = 10f;
    public float knockbackIncreaseFactor = 1.2f;
    public float verticalKnockbackFactor = 0.5f;

    private float currentKnockbackForce;

    private bool isKnockedBack = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentKnockbackForce = baseKnockbackForce;
    }

    private void Update()
    {
        if (isKnockedBack)
        {
            // Atualize o contador de tempo de recuperação
            recoveryTime -= Time.deltaTime;

            if (recoveryTime <= 0f)
            {
                isKnockedBack = false;
                recoveryTime = 1f; // Reinicie o tempo de recuperação
            }
        }
    }

    public void TakeKnockback(Vector2 direction)
    {
        if (!isKnockedBack)
        {
            Vector2 knockbackVector = new Vector2(direction.x, direction.y * verticalKnockbackFactor).normalized * currentKnockbackForce;
            rb.velocity = knockbackVector;
            isKnockedBack = true;

            Invoke(nameof(StopKnockback), knockbackDuration);
        }
    }

    private void StopKnockback()
    {
        rb.velocity = Vector2.zero;
    }

    public void IncreaseKnockbackForce()
    {
        currentKnockbackForce *= knockbackIncreaseFactor;
    }
}
