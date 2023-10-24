using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRaycast : MonoBehaviour
{
    private float playerDistance = 1f;
    [SerializeField] GameObject itemWarningObject;
    public bool playerCanTakeItem;



    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Item Warning").transform.GetChild(0).gameObject.SetActive(false);
        playerCanTakeItem = false;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, playerDistance);

        foreach (Collider collider in hitColliders)
        {
                if (collider.CompareTag("Player"))
                {
                    GameObject.Find("Item Warning").transform.GetChild(0).gameObject.SetActive(true);
                    playerCanTakeItem = true;
                }
        }
        
    }
}
