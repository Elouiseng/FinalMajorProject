using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacterScript : MonoBehaviour
{

    [SerializeField] List<GameObject> items = new List<GameObject>();
    [SerializeField] Image[] inventorySlots;
    [SerializeField] Sprite cashRegister;
    [SerializeField] GameObject levelHandler;

    private CustomerScript customerScript;
    public List<TaskDataScript> nextTask = new List<TaskDataScript>();

    private void Awake()
    {
        InitializeInventory();
    }

    void Start()
    {
    }

    void Update()
    {
        MoveToWayPoint();
    }

    void InitializeInventory()
    {
        foreach (Image image in inventorySlots)
        {
            image.gameObject.SetActive(false);
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
            if (nextTask[0].taskObjectName.Equals("CashRegister"))
            {
                if(customerScript != null && customerScript.wantsToPay == true)
                {
                    levelHandler.GetComponent<LevelUIScript>().earnedPoints += 5;
                    Destroy(customerScript.gameObject);
                }
            }
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
            customerScript = nextTask[0].taskObject.GetComponent<CustomerScript>();
            PetBehaviorScript petBehaviorScript = nextTask[0].taskObject.GetComponent<PetBehaviorScript>();
            GameObject wantedItem = null;

            if (customerScript != null && petBehaviorScript == null)
            {
                wantedItem = customerScript.GetWantedItem();
                if (wantedItem != null)
                {
                    foreach (Image slot in inventorySlots)
                    {
                        if (slot.gameObject.activeSelf && slot.sprite == wantedItem.GetComponent<SpriteRenderer>().sprite)
                        {
                            slot.gameObject.SetActive(false);
                            wantedItem.GetComponent<SpriteRenderer>().sprite = cashRegister;
                            customerScript.wantsToPay = true;
                            levelHandler.GetComponent<LevelUIScript>().earnedPoints += 5;
                            break;
                        }
                    }
                }
            }
            else if(customerScript == null && petBehaviorScript != null)
            {
                wantedItem = petBehaviorScript.GetWantedItem();
                if (wantedItem != null)
                {
                    foreach (Image slot in inventorySlots)
                    {
                        if (slot.gameObject.activeSelf && slot.GetComponent<SpriteRenderer>().sprite == wantedItem.GetComponent<SpriteRenderer>().sprite)
                        {
                            slot.gameObject.SetActive(false);
                            wantedItem.GetComponent<SpriteRenderer>().sprite = null;
                            levelHandler.GetComponent<LevelUIScript>().earnedPoints += 5;
                            break;
                        }
                    }
                }
            }
        }
    }

    void AddToInventory(GameObject item)
    {
        foreach (Image slot in inventorySlots)
        {
            if (!slot.gameObject.activeSelf) 
            {
                slot.gameObject.SetActive(true);
                slot.sprite = item.GetComponent<SpriteRenderer>().sprite;
                break; 
            }
        }
    }

}
