using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class ZiplineHandle : MonoBehaviour
{
    [Header("Path Points (in order)")]
    public List<Transform> pathPoints = new List<Transform>();
    [Header("Movement")]
    public float handleSpeed = 8f;
    public float followTolerance = 0.05f;
    public bool loop = false;

    [Header("Player")]
    public GameObject playerRigRoot;
    public CharacterController characterController;

    XRGrabInteractable grabInteractable;
    Coroutine travelCoroutine;
    int targetIndex = 0;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        grabInteractable.selectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        // Ensure player references exist
        if (playerRigRoot == null || characterController == null)
        {
            Debug.LogWarning("ZiplineHandle: playerRigRoot or characterController not assigned.");
            return;
        }

        // find nearest path point as start target
        targetIndex = FindNearestPointIndex(transform.position);
        if (travelCoroutine != null) StopCoroutine(travelCoroutine);
        travelCoroutine = StartCoroutine(TravelAlongPath());
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        if (travelCoroutine != null)
        {
            StopCoroutine(travelCoroutine);
            travelCoroutine = null;
        }
    }

    private IEnumerator TravelAlongPath()
    {
        // Snap handle to nearest point start to avoid jump:
        if (pathPoints.Count == 0)
        {
            Debug.LogWarning("ZiplineHandle: no path points assigned.");
            yield break;
        }

        // Determine whether to move forward or to next depending on distance
        int nextIndex = GetNextIndex(targetIndex);

        while (true)
        {
            Transform target = pathPoints[nextIndex];
            while (Vector3.Distance(transform.position, target.position) > followTolerance)
            {
                // Move handle toward target
                Vector3 handleDir = (target.position - transform.position).normalized;
                Vector3 handleMove = handleDir * handleSpeed * Time.deltaTime;
                transform.position += handleMove;

                Vector3 desiredPlayerPosition = transform.position; // keep player centered on handle
                Vector3 playerBasePos = characterController.transform.position;
                Vector3 delta = desiredPlayerPosition - playerBasePos;

                Vector3 movement = delta; // direct movement
                // Limit movement per frame by handle speed to keep stable:
                float maxMove = handleSpeed * Time.deltaTime * 1.5f;
                if (movement.magnitude > maxMove)
                    movement = movement.normalized * maxMove;

                characterController.Move(movement);

                yield return null;
            }

            // reached target
            targetIndex = nextIndex;

            // decide next
            nextIndex = GetNextIndex(targetIndex);

            // if we've reached the last and not looping, break
            if (!loop && targetIndex == pathPoints.Count - 1)
                break;

            yield return null;
        }

        travelCoroutine = null;
    }

    private int FindNearestPointIndex(Vector3 pos)
    {
        int best = 0;
        float bestDist = float.MaxValue;
        for (int i = 0; i < pathPoints.Count; i++)
        {
            float d = Vector3.Distance(pos, pathPoints[i].position);
            if (d < bestDist)
            {
                bestDist = d;
                best = i;
            }
        }
        return best;
    }

    private int GetNextIndex(int current)
    {
        if (pathPoints.Count == 0) return 0;
        int next = current + 1;
        if (next >= pathPoints.Count)
        {
            if (loop) next = 0;
            else next = pathPoints.Count - 1; // stay at last
        }
        return next;
    }
}
