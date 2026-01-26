using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DummyMovementController : MonoBehaviour
{
    [Header("NavMesh")]
    public NavMeshAgent agent;
    public float stoppingDistance = 0.2f;

    [Header("Start Point")]
    public Transform startPoint;

    [Header("Routes")]
    public List<Transform> easyPoints = new();
    public List<Transform> regularPoints = new();
    public List<Transform> hardPoints = new();

    [Header("Movement Settings")]
    public float easySpeed = 2f;
    public float easyAcceleration = 6f;

    public float regularSpeed = 3.5f;
    public float regularAcceleration = 8f;

    public float hardSpeed = 6f;
    public float hardAcceleration = 12f;

    [Header("Difficulty Thresholds")]
    public float easyThreshold = 30f;
    public float hardThreshold = 65f;

    [Header("Back To Start")]
    public float timeBeforeReturn = 60f;

    [Header("Visual Feedback")]
    [Tooltip("Renderer del dummy para cambiarle el color")]
    public Renderer targetRenderer;

    public Color easyColor = Color.green;
    public Color regularColor = Color.yellow;
    public Color hardColor = Color.red;
    public Color standbyColor = Color.blue;

    private List<Transform> currentRoute;
    private int currentIndex;
    private float activeTimer;

    private DummyAccuracyManager accuracyManager;

    public bool ReachedPoint { get; private set; }
    public bool TimeToReturn => activeTimer >= timeBeforeReturn;

    private void Awake()
    {
        accuracyManager = GetComponent<DummyAccuracyManager>();
        agent.stoppingDistance = stoppingDistance;
        agent.isStopped = true;


        SetColor(standbyColor);
    }

    private void Update()
    {
        if (!agent.isStopped)
        {
            activeTimer += Time.deltaTime;

            if (!agent.pathPending && agent.remainingDistance <= stoppingDistance)
            {
                MoveToNextPoint();
            }
        }
    }

    // ======================= Metodos para hablarles desde los estados =======================

    public void StandBy()
    {
        agent.isStopped = true;
        activeTimer = 0f;

        SetColor(standbyColor);
    }

    public void SetEasy()
    {
        SetColor(easyColor);


        ApplyMovement(easySpeed, easyAcceleration, easyPoints);
    }

    public void SetRegular()
    {
        SetColor(regularColor);


        ApplyMovement(regularSpeed, regularAcceleration, regularPoints);
    }

    public void SetHard()
    {

        SetColor(hardColor);


        ApplyMovement(hardSpeed, hardAcceleration, hardPoints);
    }

    public void GoBackToStart()
    {
        agent.isStopped = false;

        SetColor(standbyColor);

        agent.SetDestination(startPoint.position);
    }

    // ======================= Logica principal =======================

    private void ApplyMovement(float speed, float acceleration, List<Transform> route)
    {
        agent.isStopped = false;
        agent.speed = speed;
        agent.acceleration = acceleration;

        currentRoute = route;
        currentIndex = Random.Range(0, currentRoute.Count);

        MoveToCurrentPoint();
    }

    public void MoveToNextPoint()
    {
        ReachedPoint = false;

        currentIndex = (currentIndex + 1) % currentRoute.Count;
        MoveToCurrentPoint();
    }

    private void MoveToCurrentPoint()
    {
        agent.SetDestination(currentRoute[currentIndex].position);
    }

    public float GetCurrentAccuracy()
    {
        return accuracyManager.GetAccuracy();
    }

    // ======================= Visual =======================

    private void SetColor(Color color)
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.color = color;
        }
    }

}
