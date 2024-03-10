using UnityEngine;

public class MeleeEnemy1 : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown1;
    [SerializeField] private float range1;
    [SerializeField] private int damage1;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance1;
    [SerializeField] private BoxCollider2D boxCollider1;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer1;
    private float cooldownTimer1 = Mathf.Infinity;

    // References
    private Animator anim1;
    private Health playerHealth1;
    private EnemyPatrol enemyPatrol1;

    private void Awake()
    {
        anim1 = GetComponent<Animator>();
        enemyPatrol1 = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer1 += Time.deltaTime;

        // Attack only when player in sight?
        if (PlayerInSight1())
        {
            if (cooldownTimer1 >= attackCooldown1)
            {
                cooldownTimer1 = 0;
                anim1.SetTrigger("meleeAttack");
            }
        }

        if (enemyPatrol1 != null)
            enemyPatrol1.enabled = !PlayerInSight1();
    }

    private bool PlayerInSight1()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider1.bounds.center + transform.right * range1 * transform.localScale.x * colliderDistance1,
            new Vector3(boxCollider1.bounds.size.x * range1, boxCollider1.bounds.size.y, boxCollider1.bounds.size.z),
            0, Vector2.left, 0, playerLayer1);

        if (hit.collider != null)
            playerHealth1 = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider1.bounds.center + transform.right * range1 * transform.localScale.x * colliderDistance1,
            new Vector3(boxCollider1.bounds.size.x * range1, boxCollider1.bounds.size.y, boxCollider1.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight1())
        {
            playerHealth1.TakeDamage(damage1);
        }
    }
}
