using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCharacterScript : MonoBehaviour
{

    [SerializeField] List<GameObject> items = new List<GameObject>();
    public List<TaskDataScript> nextTask = new List<TaskDataScript>();

    [SerializeField] GameObject[] inventorySlots;
    [SerializeField] Image[] imageSlots;

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
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].SetActive(false);
        }
    }

    void MoveToWayPoint()
    {
        Debug.Log("Test 3: MoveToWayPoint");

        if (nextTask.Count > 0)
        {
            Debug.Log("Test 4: MoveToWayPoint");

            this.transform.localPosition = nextTask[0].wayPointPosition;
            this.transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, 0.0f, 0.0f);

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
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (!inventorySlots[i].activeSelf) // Find an empty slot
            {
                inventorySlots[i].SetActive(true);
                imageSlots[i].sprite = item.GetComponent<SpriteRenderer>().sprite;
                break; // Exit loop after adding the item
            }
        }
    }
}
