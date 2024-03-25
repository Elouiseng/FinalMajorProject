using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    public List<TaskDataScript> nextTask = new List<TaskDataScript>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToWayPoint();
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
}
