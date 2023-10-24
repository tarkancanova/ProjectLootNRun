using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpawn : MonoBehaviour
{
    [SerializeField] public ItemData[] itemDataList;
    [SerializeField] public ItemData itemData;
    public Vector3 spawnLocation;
    public Vector3 spawnLocation1;
    private ChestScript chestScript;

    public void SpawnItem()
    {
        spawnLocation = GameObject.Find("Chest").transform.position;
        spawnLocation.y += 1f;
        GameObject itemGameObject = Instantiate(itemData.itemModel, spawnLocation, Quaternion.identity);
    }
}
