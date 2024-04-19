using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerScript : MonoBehaviour
{
    private GameObject[] items;
    [SerializeField] GameObject orderSlot;
    [SerializeField] Sprite cashRegister;

    public bool wantsToPay;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
        wantsToPay = false;

        Invoke("ShowWantedItem", 3.0f);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ShowWantedItem()
    {
        if (items.Length > 0)
        {
            int randomIndex = Random.Range(0, items.Length);
            
            orderSlot.GetComponent<SpriteRenderer>().sprite = items[randomIndex].GetComponent<SpriteRenderer>().sprite;
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

    void MoveToCounter()
    {

    }
}
