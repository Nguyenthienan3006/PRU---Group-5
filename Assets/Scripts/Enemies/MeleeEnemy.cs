using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private float damageEnranged;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    //References
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;
    private int tele = 0;
    Transform player;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(anim.GetBool("isEnraged") == true)
        {
            if (PlayerInSight())
            {
                if (cooldownTimer >= attackCooldown)
                {
                    cooldownTimer = 0;
                    anim.SetTrigger("meleeAttackEnraged");

                }
            }
        }
        else
        {
            //Attack only when player in sight?
            if (PlayerInSight())
            {
                if (cooldownTimer >= attackCooldown)
                {
                    cooldownTimer = 0;
                    anim.SetTrigger("meleeAttack");

                }
            }
        }
        
        if(tele == 3)
        {
            tele = 0;
            anim.SetBool("tele",true);          
        }
        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
    }

    private void TelePosition()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.position;
        anim.SetBool("tele", false);

    }

    private void teleTime()
    {
        tele=tele+1;
    }

    private void DamagePlayerEnraged()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damageEnranged);
    }
}