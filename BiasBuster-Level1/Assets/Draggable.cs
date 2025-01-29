using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform originalParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Save the starting position and parent
        startPosition = transform.position;
        originalParent = transform.parent;

        // Detach from the parent to allow free dragging
        transform.SetParent(null);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Follow the mouse position
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if dropped on a valid drop zone
        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("Droparea"))
        {
            // Snap to the drop zone
            transform.SetParent(eventData.pointerEnter.transform);
            transform.position = eventData.pointerEnter.transform.position;
        }
        else
        {
            // Return to the original position if dropped elsewhere
            transform.position = startPosition;
            transform.SetParent(originalParent);
        }
    }
}
