using UnityEngine;
using UnityEngine.AI;

public class CompetitiveAI : MonoBehaviour
{
    [Header("Navigation")]
    public NavMeshAgent agent;
    public float detectionRange = 15f;
    public float shootingRange = 7f;

    [Header("Combat")]
    public GunController gun;
    public float fireRate = 0.3f;
    private float fireTimer;

    [Header("Score")]
    public int aiScore;
    public ScoreManager scoreManager;

    [Header("Runtime")]
    public Transform currentTarget;
    public Vector3 randomPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Vector3 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }

    public void StopMovement()
    {
        agent.isStopped = true;
    }

    public void ShootTarget()
    {
        if (currentTarget == null)
            return;

        transform.LookAt(currentTarget);

        fireTimer += Time.deltaTime;
        if (fireTimer < fireRate)
            return;

        fireTimer = 0f;

        gun.Shoot();

        TargetMoving target = currentTarget.GetComponentInParent<TargetMoving>();
        if (target != null)
        {
            target.TakeDamage();

            if (target.IsDead())
            {
                currentTarget = null;
                AddScore(1);
            }
        }
    }


    public void AddScore(int amount)
    {
        aiScore += amount;
    }

    public bool IsTargetInRange(float range)
    {
        if (currentTarget == null) return false;
        return Vector3.Distance(transform.position, currentTarget.position) <= range;
    }

    public void PickRandomPoint(float radius = 20f)
    {
        Vector3 randomDir = Random.insideUnitSphere * radius;
        randomDir += transform.position;

        if (NavMesh.SamplePosition(randomDir, out NavMeshHit hit, radius, NavMesh.AllAreas))
        {
            randomPoint = hit.position;
        }
    }

    public Transform FindNearestDummy()
    {
        GameObject[] dummies = GameObject.FindGameObjectsWithTag("Dummies");

        float minDist = Mathf.Infinity;
        Transform closest = null;

        foreach (var d in dummies)
        {
            float dist = Vector3.Distance(transform.position, d.transform.position);
            if (dist < minDist && dist <= detectionRange)
            {
                minDist = dist;
                closest = d.transform;
            }
        }

        return closest;
    }

    public bool IsPlayerWinning()
    {
        if (scoreManager == null)
            return false;

        return scoreManager.GetDestroyedTargets() > aiScore;
    }

}
