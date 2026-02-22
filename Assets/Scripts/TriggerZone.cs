using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public TutorialManager manager;
    public int zoneIndex; // 0,1,2
    public string playerTag = "Player"; 

    private void OnTriggerEnter(Collider other)
    {

        if (!other.CompareTag(playerTag)) return;

        manager.OnTriggerZoneCleared(zoneIndex);
    }
}
