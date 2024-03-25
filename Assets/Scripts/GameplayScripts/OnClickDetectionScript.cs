using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDetectionScript : MonoBehaviour
{
    [SerializeField] private PlayerCharacterScript characterScript;
    [SerializeField] private GameObject navigatorsParent;
    [SerializeField] private GameObject navigatorsWayPoint;

    private void Awake()
    {
        characterScript = FindFirstObjectByType<PlayerCharacterScript>();

        navigatorsParent = this.transform.parent.gameObject;
        navigatorsWayPoint = this.transform.GetChild(0).gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //Debug.Log("Test 1: OnMouseDown");
        //Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

        //if (Physics.Raycast(ray, out RaycastHit hit))
        //{
            Debug.Log("Test 2 : OnMouseDown");

            characterScript.nextTask.Add(new TaskDataScript(navigatorsParent.name, navigatorsWayPoint.transform.position));
        //}
    }
}
