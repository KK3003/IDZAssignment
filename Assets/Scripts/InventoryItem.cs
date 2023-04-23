using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Direction direction;

    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public InventoryList inventoryList;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
       // inventoryList = GetComponentInParent<InventoryList>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Get the position of the item in the inventory panel
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out Vector2 pos);
        var inventoryPos = canvas.transform.TransformPoint(pos);

        // Check if the item was dropped in the inventory panel
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, inventoryPos, canvas.worldCamera))
        {
            // Add the item to the inventory list
            inventoryList.AddItem(this);
        }
        else
        {
            // Remove the item from the inventory list
            inventoryList.RemoveItem(this);
        }
    }
}