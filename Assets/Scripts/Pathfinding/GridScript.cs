using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public float width;
    public float height;
    public float cellSize;
    public Vector3 originPosition;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.gray;

        for (float x = 0; x < width; x += cellSize)
        {
            for (float y = 0; y < height; y += cellSize)
            {
                Vector3 cellPosition = GetWorldPosition(x, y);
                Gizmos.DrawWireCube(cellPosition, new Vector3(cellSize, cellSize, 0));

            }
        }
    }

    private Vector3 GetWorldPosition(float x, float y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }
}
