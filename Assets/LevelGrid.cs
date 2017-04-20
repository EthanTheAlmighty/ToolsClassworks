using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour {

    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;

    public float gridSize = 1.5f;

    public int row, col;

    public void GridGizmo(int cols, int rows)
    {
        for(int i = 0; i <= cols; i++)
        {
            Gizmos.DrawLine(new Vector3(i * gridSize, 0, 0), new Vector3(i * gridSize, rows * gridSize, 0));
        }
        for (int i = 0; i <= rows; i++)
        {
            Gizmos.DrawLine(new Vector3(0, i * gridSize, 0), new Vector3(cols * gridSize, i * gridSize, 0));
        }
    }

    public void GridFrame(int rows, int cols)
    {
        Gizmos.color = CustomColors.puce;
        Gizmos.DrawLine(Vector3.zero, Vector3.up * rows * gridSize);
        Gizmos.DrawLine(new Vector3(cols*gridSize, 0, 0), new Vector3(cols * gridSize, rows * gridSize, 0));
        Gizmos.DrawLine(Vector3.zero, Vector3.right * cols * gridSize);
        Gizmos.DrawLine(Vector3.up * rows * gridSize, new Vector3(cols * gridSize, rows * gridSize, 0));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = normalColor;
        GridGizmo(col, row);
    }

    public Vector3 GridToWorld(int col, int row)
    {
        Vector3 gridPoint = new Vector3(col*gridSize + gridSize/2, row*gridSize + gridSize/2);
        return gridPoint;
    }

    public Vector3 WorldToGrid(Vector3 point)
    {
        Vector3 gridPoint = new Vector3((int)point.x / gridSize, (int)point.y / gridSize, 0);
        return gridPoint;
    }

    public bool IsInsideGridBounds(Vector3 point)
    {
        float minX = 0;
        float maxX = gridSize * col;
        float minY = 0;
        float maxY = gridSize * row;

        return (point.x >= minX && point.x <= maxX && point.y >= minY && point.y <= maxY);
    }

    public bool IsInsideGridBounds(int cols, int rows)
    {
        return (cols >= 0 && cols < col && rows >= 0 && rows < row);
    }

    void OnDrawGizmosSelected()
    {
        GridFrame(row, col);
    }
}
