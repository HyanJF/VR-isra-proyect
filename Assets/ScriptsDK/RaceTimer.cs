using UnityEngine;
using TMPro;

public class RaceTimer : MonoBehaviour
{
    [Header("Display (assign one)")]
    public TextMeshProUGUI tmpDisplay;

    [Header("Options")]
    public bool startOnPlay = true;
    public Transform followHandTransform;
    public Vector3 followLocalOffset = Vector3.zero;
    public bool followRotation = false;

    private float elapsed = 0f;
    private bool running = false;
    private bool finished = false;

    void Start()
    {
        if (startOnPlay)
            StartTimer();
    }

    void Update()
    {
        if (running && !finished)
        {
            elapsed += Time.deltaTime;
            UpdateDisplay(elapsed);
        }

        if (followHandTransform != null)
        {
            transform.position = followHandTransform.TransformPoint(followLocalOffset);
            if (followRotation)
                transform.rotation = followHandTransform.rotation;
        }
    }

    public void StartTimer()
    {
        elapsed = 0f;
        running = true;
        finished = false;
        UpdateDisplay(elapsed);
    }

    public void StopTimer()
    {
        running = false;
        finished = true;
        UpdateDisplay(elapsed);
    }

    public void ResetTimer()
    {
        elapsed = 0f;
        running = false;
        finished = false;
        UpdateDisplay(elapsed);
    }

    private void UpdateDisplay(float time)
    {
        int minutes = (int)(time / 60f);
        int seconds = (int)(time % 60f);
        int milliseconds = (int)((time - Mathf.Floor(time)) * 1000f);

        string text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);

        if (tmpDisplay != null)
            tmpDisplay.text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (finished) return;

        if (other.CompareTag("Finish"))
        {
            StopTimer();
        }
    }
}
