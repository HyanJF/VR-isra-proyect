using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRSimpleInteractable))]
public class SceneResetButton : MonoBehaviour
{
    XRSimpleInteractable interactable;
    public RaceTimer raceTimer;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnPressed);
    }

    void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnPressed);
    }

    void OnPressed(SelectEnterEventArgs args)
    {
        if (raceTimer != null)
            raceTimer.StopTimer();

        // Reload the currently active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
