using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        InitializeInventory();
    }

    // Update is called once per frame
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

    void AddToInventory(GameObject item)
    {
        foreach (GameObject slot in inventorySlots)
        {
            if (!slot.activeSelf) // Find an empty slot
            {
                slot.SetActive(true);
                slot.GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                break; // Exit loop after adding the item
            }
        }
    }
}
