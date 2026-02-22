using UnityEngine;


public class BoardAssemblyChecker : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor kingSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor queenSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor bishopSocket;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;

    private void Start()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.enabled = false; // Disable grabbing at start
    }

    private void Update()
    {
        if (grab.enabled) return; // already enabled

        if (kingSocket.hasSelection &&
            queenSocket.hasSelection &&
            bishopSocket.hasSelection)
        {
            grab.enabled = true; // Enable grabbing once all pieces placed
            Debug.Log("Board fully assembled. Grabbing enabled.");
        }
    }
}
