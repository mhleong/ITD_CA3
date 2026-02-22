using UnityEngine;


public class TutorialManager : MonoBehaviour
{
    [Header("Trigger Zones (in order)")]  
    public GameObject[] triggerZones; 

    [Header("Teleport Areas (in order)")]
    public UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationArea teleportArea1;
    public UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation.TeleportationArea teleportArea2;

    [Header("Teleport Destination Triggers (in order)")]    // These are the trigger colliders placed at the teleport destinations to detect when player arrives
    public TeleportDestinationTrigger teleportDest1;
    public TeleportDestinationTrigger teleportDest2;

    [Header("Congrats UI")]
    public GameObject congratsUI;

    [Header("Chess Activity to Unlock After Tutorial")]
    public GameObject chessActivity;

    private int currentTriggerIndex = 0;    // Tracks which trigger zone the player needs to clear next
    private int teleportStep = 0;   // 0 = not started, 1 = cleared triggers and can teleport to dest 1,
                                    //  2 = teleported to dest 1 and can teleport to dest 2,
                                    //  3 = completed tutorial


    private void Start()
    {
        if (chessActivity != null) chessActivity.SetActive(false);

        // Enable only Trigger 1
        for (int i = 0; i < triggerZones.Length; i++)
            triggerZones[i].SetActive(i == 0);

        // Disable teleport areas until triggers cleared
        if (teleportArea1) teleportArea1.enabled = false;
        if (teleportArea2) teleportArea2.enabled = false;

        // Set manager reference in teleport destination triggers
        if (teleportDest1) teleportDest1.manager = this;
        if (teleportDest2) teleportDest2.manager = this;

        // Hide congrats UI at start
        if (congratsUI) congratsUI.SetActive(false);
    }

    // Called by TriggerZone script when player enters the correct trigger
    public void OnTriggerZoneCleared(int zoneIndex)
    {
        // Only accept the current required zone
        if (zoneIndex != currentTriggerIndex) return;

        // Disable current zone
        triggerZones[currentTriggerIndex].SetActive(false);
        currentTriggerIndex++;

        // If there is a next zone, enable it
        if (currentTriggerIndex < triggerZones.Length)
        {
            triggerZones[currentTriggerIndex].SetActive(true);
            return;
        }

        // All trigger zones cleared -> enable teleport area 1
        if (teleportArea1) teleportArea1.enabled = true;
        teleportStep = 1;
    }

    
    /// <summary>
    /// This method ensures the player teleports to the correct destination in order (dest 1 then dest 2) before showing congrats UI.
    /// </summary>
    public void OnTeleportedToDestination(int destinationIndex)     // Called by TeleportDestinationTrigger when XR Origin enters destination trigger
    {
        // destinationIndex: 1 or 2
        if (teleportStep == 1 && destinationIndex == 1)
        {
            // Enable teleport area 2 only after reaching destination 1
            if (teleportArea2) teleportArea2.enabled = true;
            teleportStep = 2;
        }
        else if (teleportStep == 2 && destinationIndex == 2)
        {
            // Finished tutorial
            if (congratsUI) congratsUI.SetActive(true);
            teleportStep = 3;
            TutorialCompleted();
        }
    }

    
    public void DismissCongrats()
    {
        if (congratsUI) congratsUI.SetActive(false);   
    }

    private void TutorialCompleted()
    {
        if (chessActivity != null) chessActivity.SetActive(true);
    }
}
