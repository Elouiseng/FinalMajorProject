using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskDataScript
{
    public string taskObjectName;
    public Vector2 wayPointPosition;

    public TaskDataScript(string _taskObjectName, Vector2 _wayPointPosition)
    {
        this.taskObjectName = _taskObjectName;
        this.wayPointPosition = _wayPointPosition;
    }
}
