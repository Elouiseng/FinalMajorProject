using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDetectionScript : MonoBehaviour
{ 
    [SerializeField] GameObject navigatorsWayPoint;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        //wayPoint.x = GetComponentInChildren<Transform>().position.x;
        //wayPoint.y = GetComponentInChildren<Transform>().position.y;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        Debug.Log("Clicked " + navigatorsWayPoint.transform.localPosition);

        
    }
}
