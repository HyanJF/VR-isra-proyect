using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int destroyedTargets = 0;
    public TextMeshProUGUI scoreText;

    public void OnTargetDestroyed()
    {
        destroyedTargets++;
        scoreText.text = destroyedTargets + " / 15 " ;

        Debug.Log($"Target Destroyed! Total Destroyed: {destroyedTargets}");
    }
}
