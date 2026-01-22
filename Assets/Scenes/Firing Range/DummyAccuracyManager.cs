using UnityEngine;

public class DummyAccuracyManager : MonoBehaviour
{
    [Header("Accuracy Settings")]
    [Tooltip("Time window in seconds to evaluate acuracy")]
    public float evaluationWindow = 15f;

    public int shotsFired;
    public int hits;
    public float timer;

    public bool HasBeenActivated { get; private set; }

    private void Update()
    {
        // Solo contamos tiempo despues del primer disparo que es lo que activa el dummy

        if (!HasBeenActivated)
            return;

        timer += Time.deltaTime;

        if (timer >= evaluationWindow)
        {
            ResetCounters();
        }
    }

  
    // Called by the weapon when a shot is fired
    
    public void RegisterShot()
    {
       
            

        shotsFired++;
    }

    
    // Called when a projectile hits the dummy
    
    public void RegisterHit()
    {
        if (!HasBeenActivated)
        {
            HasBeenActivated = true;
        }
        hits++;
    }

   
    // Returns accuracy percentage (0 - 100)
    
    public float GetAccuracy()
    {
        if (shotsFired == 0)
            return 0f;

        return (float)hits / shotsFired * 100f;
    }

   
    // Resets the counters after the evaluation window
    
    public void ResetCounters()
    {
       
        shotsFired = 0;
        hits = 0;
        timer = 0f;
    }

    public void ResetActivation()
    {
        HasBeenActivated = false;
        shotsFired = 0;
        hits = 0;
        timer = 0f;
    }
}
