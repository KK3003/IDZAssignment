using System.Collections.Generic;
using UnityEngine;

public class PlayButton : Subject
{
    public InventoryList inventoryList;
    public GameObject linePrefab;
    public Transform lineParent;
    public Vector2 startingPoint;
   
    public List<Direction> properSequence = new List<Direction>();

    public void OnButtonClick()
    {
        List<Direction> userSequence = new List<Direction>();

        // Get the direction of each item in the inventory list
        foreach (InventoryItem item in inventoryList.items)
        {
            userSequence.Add(item.direction);
        }

        List<Direction> inventorySequence = new List<Direction>();

        // Get the direction of each item in the inventory list sequence
        foreach (InventoryItem item in inventoryList.items)
        {
            inventorySequence.Add(item.direction);
        }

        // Check if the user's sequence matches the proper sequence
        if (CompareSequences(userSequence, properSequence))
        {
            DrawLine(inventoryList.items);
            NotifyObservers(UIPanels.LevelComplete);
        }
        else
        {
            DrawLine(inventoryList.items);
            NotifyObservers(UIPanels.LevelReload);
        }
    }

    private bool CompareSequences(List<Direction> sequence1, List<Direction> sequence2)
    {
        if (sequence1.Count != sequence2.Count)
        {
            Debug.Log("Sequence count not match");
            return false;
        }

        for (int i = 0; i < sequence1.Count; i++)
        {
            if (sequence1[i] != sequence2[i])
            {
                return false;
            }
        }

        return true;
    }

    private void DrawLine(List<InventoryItem> inventoryList)
    {
        // Create a new line game object
        GameObject newLine = Instantiate(linePrefab, lineParent);

        // Set the starting position of the line
        Vector2 currentPosition = startingPoint;

        // Draw the line based on the inventory list
        List<InventoryItem> inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < inventoryList.Count; i++)
        {
            Vector2 nextPosition = currentPosition;

            // Update the position based on the inventory item direction
            switch (inventoryList[i].direction)
            {
                case Direction.Up:
                    nextPosition += Vector2.up;
                    break;
                case Direction.Down:
                    nextPosition += Vector2.down;
                    break;
                case Direction.Left:
                    nextPosition += Vector2.left;
                    break;
                case Direction.Right:
                    nextPosition += Vector2.right;
                    break;
            }

            // Draw a line between the current position and the next position
            LineRenderer lineRenderer = newLine.GetComponent<LineRenderer>();
            lineRenderer.positionCount = i + 2;
            lineRenderer.SetPosition(i, currentPosition);
            lineRenderer.SetPosition(i + 1, nextPosition);

            // Update the current position
            currentPosition = nextPosition;
        }
    }
}
