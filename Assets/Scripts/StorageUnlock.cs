using UnityEngine;

public class StorageUnlock : MonoBehaviour
{
    public Transform lid; 
    public float moveUpAmount = 0.5f;  // How high it moves
    public float moveSpeed = 4f;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool opened = false;

    private void Start()
    {
        if (lid != null)
        {
            closedPos = lid.localPosition;
            openPos = closedPos + Vector3.up * moveUpAmount;
        }
    }

    public void OpenLid()
    {
        opened = true;
    }

    private void Update()
    {
        if (!opened || lid == null) return;

        lid.localPosition = Vector3.Lerp(lid.localPosition, openPos, Time.deltaTime * moveSpeed);
    }
}
