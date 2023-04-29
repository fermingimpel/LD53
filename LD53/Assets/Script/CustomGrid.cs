using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    [SerializeField] private int width = 0;
    [SerializeField] private int height = 0;
    [SerializeField] private float cellSize = 10;
    [SerializeField] private bool shouldDraw = false;
    private Vector2 offset;
    private int[,] gridArray;

    private void Start()
    {
        UpdateGrid();
    }

    private void OnValidate()
    {
        UpdateGrid();
    }

    public void UpdateGrid()
    {
        offset = new Vector2(0, 0);

        gridArray = new int[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (shouldDraw)
            Draw();
    }

    public void Draw()
    {
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                Gizmos.DrawLine(GetWorldPos(x, y), GetWorldPos(x + cellSize, y));
                Gizmos.DrawLine(GetWorldPos(x, y), GetWorldPos(x, y + cellSize));
            }
        }
    }

    public Vector3 GetWorldPos(float x, float y)
    {
        return new Vector3(x * cellSize, 0, y * cellSize);
    }

    public Vector3 SetHouseLocation()
    {
        int x;
        int y;

        do
        {
            x = Random.Range(0, width);
            y = Random.Range(0, height);

        } while (gridArray[x, y] == 1);

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if ((j < height && j >= 0) && (i < width && i >= 0))
                    gridArray[i, j] = 1;
            }
        }

        Vector3 newPos = GetWorldPos(x, y);
        newPos.y = Random.Range(-height, height);

        return newPos;
    }
}