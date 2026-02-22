using UnityEngine;

public class TeleportDestinationTrigger : MonoBehaviour
{
    [HideInInspector] public TutorialManager manager;
    public int destinationIndex = 1; // 1 or 2
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;
        manager.OnTeleportedToDestination(destinationIndex);

        Debug.Log("Entered Dest " + destinationIndex + " by: " + other.name);
    }
}

