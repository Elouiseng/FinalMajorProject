using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCharacterScript : MonoBehaviour
{

    [SerializeField] List<GameObject> items = new List<GameObject>();
    [SerializeField] GameObject[] inventorySlots;

    public List<TaskDataScript> nextTask = new List<TaskDataScript>();

    private void Awake()
    {
        
    }

    void Start()
    {
        InitializeInventory();
    }

    void Update()
    {
        MoveToWayPoint();
    }

    void InitializeInventory()
    {
        foreach (GameObject slot in inventorySlots)
        {
            slot.SetActive(false);
        }
    }

    void MoveToWayPoint()
    {
        //Debug.Log("Test 3: MoveToWayPoint");

        if (nextTask.Count > 0)
        {
            //Debug.Log("Test 4: MoveToWayPoint");

            this.transform.localPosition = nextTask[0].wayPointPosition;
            TakeItem();
            RemoveItem();
            nextTask.RemoveAt(0);
        }
    }

    void TakeItem()
    {
        foreach (var item in items)
        {
            if (item.name.Equals(nextTask[0].taskObjectName))
            {
                AddToInventory(item);
                break;
            }
        }
    }

    void RemoveItem()
    {
        if (nextTask[0].taskObjectTag.Equals("NPC"))
        {
            CustomerScript customerScript = nextTask[0].taskObject.GetComponent<CustomerScript>();

            if (customerScript != null)
            {
                GameObject wantedItem = customerScript.GetWantedItem();
                if (wantedItem != null)
                {
                    foreach (GameObject slot in inventorySlots)
                    {
                        if (slot.activeSelf && slot.GetComponent<SpriteRenderer>().sprite == wantedItem.GetComponent<SpriteRenderer>().sprite)
                        {
                            slot.SetActive(false); 
                            Destroy(wantedItem); 
                            break;
                        }
                    }
                }
            }
        }
    }

    void AddToInventory(GameObject item)
    {
        foreach (GameObject slot in inventorySlots)
        {
            if (!slot.activeSelf) 
            {
                slot.SetActive(true);
                slot.GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                break; 
            }
        }
    }

}
