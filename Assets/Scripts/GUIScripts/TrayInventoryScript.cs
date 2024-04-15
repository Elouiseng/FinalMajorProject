using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class TrayInventoryScript : MonoBehaviour
{
    public Transform[] itemPickupPoints;
    public Transform[] deliveryPoints;
    public GameObject[] itemPrefabs;
    public int maxItemsOnTray = 4;

    private List<GameObject> itemsOnTray = new List<GameObject>();

    void OnMouseDown()
    {
        if ( )
        {
            if (itemsOnTray.Count <= maxItemsOnTray)
            {
                PickUpItem();
            }
        }
        else
        {
            DeliverItem();
        }
    }

    void PickUpItem()
    {
        foreach (Transform pickupPoint in itemPickupPoints)
        {
            RaycastHit hit;
            if (Physics.Raycast(pickupPoint.position, pickupPoint.forward, out hit, 2f))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    // Pick up the item
                    item.PickUp(pickupPoint);
                    // Determine which item prefab to instantiate based on item type
                    GameObject itemPrefab = GetItemPrefabByType(item.Type);
                    if (itemPrefab != null)
                    {
                        // Instantiate visual representation of the item on the tray
                        GameObject itemObject = Instantiate(itemPrefab, transform.position, Quaternion.identity, transform);
                        itemsOnTray.Add(itemObject);
                        return; // Exit loop after picking up an item
                    }
                }
            }
        }
    }

    void DeliverItem()
    {
        // Loop through delivery points
        foreach (Transform deliveryPoint in deliveryPoints)
        {
            // Check if there's a customer at the delivery point
            Customer customer = deliveryPoint.GetComponentInChildren<Customer>();
            if (customer != null && itemsOnTray.Count > 0)
            {
                // Check if the item type matches the customer's desired type
                ItemType customerDesiredType = customer.GetDesiredItemType();
                foreach (GameObject itemObject in itemsOnTray)
                {
                    Item item = itemObject.GetComponent<Item>();
                    if (item.Type == customerDesiredType)
                    {
                        // Deliver the item to the customer
                        customer.ReceiveItem(itemObject);
                        itemsOnTray.Remove(itemObject);
                        Destroy(itemObject); // Remove visual representation from the tray
                        return; // Exit loop after delivering an item
                    }
                }
            }
        }
    }

    GameObject GetItemPrefabByType(ItemType type)
    {
        // Search for the corresponding item prefab based on item type
        foreach (GameObject itemPrefab in itemPrefabs)
        {
            Item itemComponent = itemPrefab.GetComponent<Item>();
            if (itemComponent != null && itemComponent.Type == type)
            {
                return itemPrefab;
            }
        }
        return null; // Return null if no corresponding prefab is found
    }
}
