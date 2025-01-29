using UnityEngine;

public class DragObject3 : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    [SerializeField] private Vector3 resetPosition = new Vector3(0f,0f, 0f); // Specific reset position
    [SerializeField] private Collider2D badarea_0; // Reference to the restricted area (2D collider)

    private bool isInTriggerArea = false; // To track whether the object is inside the trigger area

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        offset = transform.position - mainCamera.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(mousePosition) + offset;

        if (!isInTriggerArea)
        {
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        if (isInTriggerArea)
        {
            transform.position = resetPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == badarea_0)
        {
            isInTriggerArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == badarea_0)
        {
            isInTriggerArea = false;
        }
    }
}
