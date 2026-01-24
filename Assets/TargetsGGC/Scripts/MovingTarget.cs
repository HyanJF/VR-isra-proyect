using UnityEngine;

public class TargetMoving : MonoBehaviour
{
    [Header("HP Settings")]
    [SerializeField] private int maxHP = 3;
    private int currentHP;

    [Header("Movement Settings")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 3f;

    [Header("Score")]
    [SerializeField] private ScoreManager scoreManager;

    private int currentIndex = 0;
    private int direction = 1;

    private void Start()
    {
        currentHP = maxHP;

        if (waypoints == null || waypoints.Length < 2)
        {
            Debug.LogWarning("La diana necesita al menos 2 waypoints para moverse.");
        }
    }

    private void Update()
    {
        MoveBetweenWaypoints();
    }

    private void MoveBetweenWaypoints()
    {
        if (waypoints == null || waypoints.Length < 2) return;

        Transform target = waypoints[currentIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentIndex += direction;

            if (currentIndex == waypoints.Length - 1)
                direction = -1;
            else if (currentIndex == 0)
                direction = 1;
        }
    }

    public void TakeDamage()
    {
        currentHP--;

        Debug.Log($"Target Hit! HP Left: {currentHP}");

        if (currentHP <= 0)
        {
            if (scoreManager != null)
                scoreManager.OnTargetDestroyed();
            else
                Debug.LogWarning("ScoreManager no asignado en este Target.");

            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        return currentHP <= 0;
    }
}
