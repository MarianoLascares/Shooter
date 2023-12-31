using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Sight))]
public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {GoToBase, AttackBase, ChasePlayer, AttackPlayer}

    public EnemyState currentState;

    private Sight _sight;

    private Transform baseTransform;
    public float baseAttackDistance, playerAttackDistance;

    private NavMeshAgent agent;

    private Animator animator;

    public Weapon weapon;
    private void Awake()
    {
        _sight = GetComponent<Sight>();
        baseTransform = GameObject.FindWithTag("Base").transform;
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case EnemyState.GoToBase:
                GoToBase();
                break;
            case EnemyState.AttackBase:
                AttackToBase();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
        }
    }

    void GoToBase()
    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        
        if (_sight.detectedTarget != null)
        {
            currentState = EnemyState.ChasePlayer;
            return;
        }

        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if (distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackToBase()
    {
        agent.isStopped = true;
        LookAt(baseTransform.position);
        ShootTarget();
    }

    void ChasePlayer()
    {
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        agent.isStopped = false;
        agent.SetDestination(_sight.detectedTarget.transform.position);
        
        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    void AttackPlayer()
    {
        agent.isStopped = true;
        if (_sight.detectedTarget == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }
        LookAt(_sight.detectedTarget.transform.position);
        ShootTarget();

        float distanceToPlayer = Vector3.Distance(transform.position, _sight.detectedTarget.transform.position);
        if (distanceToPlayer > playerAttackDistance * 1.2f)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void ShootTarget()
    {
        if (weapon.ShootBullet("Enemy Bullet", 0.2f))
        {
            animator.SetTrigger("Shoot Bullet");
        }
    }

    void LookAt(Vector3 targetPos)
    {
        Vector3 directionToLook = Vector3.Normalize(targetPos - transform.position);
        directionToLook.y = 0;
        transform.parent.forward = directionToLook;
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }
}
