using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskDataScript
{
    public GameObject taskObject;
    public string taskObjectName;
    public string taskObjectTag;
    public Vector2 wayPointPosition;

    public TaskDataScript(GameObject _taskObject, string _taskObjectName, string _taskObjectTag, Vector2 _wayPointPosition)
    {
        this.taskObject = _taskObject;
        this.taskObjectName = _taskObjectName;
        this.taskObjectTag = _taskObjectTag;
        this.wayPointPosition = _wayPointPosition;
    }
}
