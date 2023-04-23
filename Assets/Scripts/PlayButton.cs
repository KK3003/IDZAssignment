using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public InventoryList inventoryList;
    public InventoryListSequence inventoryListSequence;

    private List<Direction> properSequence = new List<Direction>() { Direction.Up, Direction.Down, Direction.Left, Direction.Right };

    public void OnButtonClick()
    {
        List<Direction> userSequence = new List<Direction>();

        // Get the direction of each item in the inventory list
        foreach (InventoryItem item in inventoryList.items)
        {
            userSequence.Add(item.direction);
        }

        // Check if the user's sequence matches the proper sequence
        if (CompareSequences(userSequence, properSequence))
        {
            Debug.Log("Sequence matches!");
        }
        else
        {
            Debug.Log("Sequence does not match.");
        }
    }

    private bool CompareSequences(List<Direction> sequence1, List<Direction> sequence2)
    {
        if (sequence1.Count != sequence2.Count)
        {
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
}
