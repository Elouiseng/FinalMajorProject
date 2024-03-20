using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDetectionScript : MonoBehaviour
{
    [SerializeField] private PlayerCharacterScript characterScript;
    //[SerializeField] private GameObject navigator;
    [SerializeField] private GameObject navigatorsWayPoint;

    private void Awake()
    {
        characterScript = FindFirstObjectByType<PlayerCharacterScript>();

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
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

        characterScript.nextTask.Add(this.gameObject);
    }
}
