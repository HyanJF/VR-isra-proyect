using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSocketInteractor))]
public class HolsterSocket : MonoBehaviour
{
    [Header("Attach transform - where the gun should snap to")]
    public Transform attachTransform;

    [Header("Options")]
    public bool disablePhysicsOnSocket = true; // set kinematic + disable gravity on snap
    public bool allowOnlySpecificTag = true;
    public string allowedTag = "Gun";

    XRSocketInteractor socket;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
        if (attachTransform != null)
            socket.attachTransform = attachTransform;

        socket.selectEntered.AddListener(OnSocketed);
        socket.selectExited.AddListener(OnUnsocketed);
    }

    void OnDestroy()
    {
        socket.selectEntered.RemoveListener(OnSocketed);
        socket.selectExited.RemoveListener(OnUnsocketed);
    }

    private void OnSocketed(SelectEnterEventArgs args)
    {
        if (allowOnlySpecificTag && args.interactableObject != null)
        {
            var go = args.interactableObject.transform.gameObject;
            if (!go.CompareTag(allowedTag))
            {
                return;
            }
        }

        if (attachTransform != null && args.interactableObject != null)
        {
            var obj = args.interactableObject.transform;
            obj.SetPositionAndRotation(attachTransform.position, attachTransform.rotation);
        }

        if (disablePhysicsOnSocket)
        {
            Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }
        }
    }

    private void OnUnsocketed(SelectExitEventArgs args)
    {
        if (args.interactableObject != null && disablePhysicsOnSocket)
        {
            Rigidbody rb = args.interactableObject.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;
            }
        }
    }
}
