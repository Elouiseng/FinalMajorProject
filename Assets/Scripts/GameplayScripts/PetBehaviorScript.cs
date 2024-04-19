using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehaviorScript : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] GameObject orderSlot;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowWantedItem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShowWantedItem()
    {
        yield return new WaitForSeconds(Random.Range(10f, 25f)); 

        if (item != null && orderSlot.GetComponent<SpriteRenderer>() != null)
        {
            orderSlot.GetComponent<SpriteRenderer>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            Debug.LogWarning("No item or Slot Sprite");
        }
    }

    public GameObject GetWantedItem()
    {
        if (orderSlot.GetComponent<SpriteRenderer>().sprite != null)
        {
            return orderSlot.gameObject;
        }
        else
        {
            return null;
        }

    }
}
