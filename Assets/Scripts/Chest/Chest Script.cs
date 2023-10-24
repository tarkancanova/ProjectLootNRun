using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    private List<Vector3> _directionsToCheck = new() { Vector3.right, Vector3.forward + Vector3.right, Vector3.left, Vector3.left + Vector3.forward, Vector3.back, Vector3.back + Vector3.right, Vector3.back, Vector3.left, Vector3.forward };
    private float playerDistance = 0.75f;
    public bool chestCanBeOpened = false;
    private float chestLockOpenDistance = 0.25f;
    public bool chestOpened = false;

    public void Update()
    {
        chestCanBeOpened = false;
        chestOpened = false;
        ChestPlayerCheck();
    }

    public void ChestPlayerCheck()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, playerDistance);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player") && !chestOpened)
            {
                chestCanBeOpened = true;
            }
        }
    }

    public void OpenChest()
    {
        Vector3 chestLockPosition = transform.GetChild(4).position;
        Vector3 newChestLockPosition = new Vector3(chestLockPosition.x, chestLockPosition.y, chestLockPosition.z + chestLockOpenDistance);
        transform.GetChild(4).position = newChestLockPosition;
        FindObjectOfType<ItemSpawn>().SpawnItem();
        chestOpened = true;
    }
}
