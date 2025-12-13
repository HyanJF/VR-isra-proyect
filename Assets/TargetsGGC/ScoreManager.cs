using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int destroyedTargets = 0;

    public void OnTargetDestroyed()
    {
        destroyedTargets++;

        Debug.Log($"Target Destroyed! Total Destroyed: {destroyedTargets}");
    }
}
