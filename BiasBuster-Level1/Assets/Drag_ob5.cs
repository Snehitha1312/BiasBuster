// using UnityEngine;

// public class DragObject4 : MonoBehaviour
// {
//     private Vector3 offset;
//     private Camera mainCamera;
//     [SerializeField] private Vector3 resetPosition = new Vector3(-5.566766f, -2.01788f, 0f); // Specific reset position
//     [SerializeField] private Collider2D badarea_0; // Reference to the restricted area (2D collider)

//     private bool isInTriggerArea = false; // To track whether the object is inside the trigger area

//     private void Start()
//     {
//         mainCamera = Camera.main;
//     }

//     private void OnMouseDown()
//     {
//         Vector3 mousePosition = Input.mousePosition;
//         mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
//         offset = transform.position - mainCamera.ScreenToWorldPoint(mousePosition);
//     }

//     private void OnMouseDrag()
//     {
//         Vector3 mousePosition = Input.mousePosition;
//         mousePosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
//         Vector3 newPosition = mainCamera.ScreenToWorldPoint(mousePosition) + offset;

//         if (!isInTriggerArea)
//         {
//             transform.position = newPosition;
//         }
//     }

//     private void OnMouseUp()
//     {
//         if (isInTriggerArea)
//         {
//             transform.position = resetPosition;
//         }
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other == badarea_0)
//         {
//             isInTriggerArea = true;
//         }
//     }

//     private void OnTriggerExit2D(Collider2D other)
//     {
//         if (other == badarea_0)
//         {
//             isInTriggerArea = false;
//         }
//     }
// }
using UnityEngine;

public class DragObject4 : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    [SerializeField] private Vector3 resetPosition = new Vector3(-5.566766f, -2.01788f, 0f); // Specific reset position
    [SerializeField] private Collider2D badarea_0; // Reference to the restricted area (2D collider)
    [SerializeField] private Collider2D disappearingArea; // Reference to the disappearing area (2D collider)

    private bool isInTriggerArea = false; // To track whether the object is inside the restricted area
    private bool isInDisappearingArea = false; // To track whether the object is inside the disappearing area

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

        if (!isInTriggerArea && !isInDisappearingArea)
        {
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        if (isInTriggerArea)
        {
            transform.position = resetPosition; // Reset the object if inside restricted area
        }
        else if (isInDisappearingArea)
        {
            gameObject.SetActive(false); // Make the object disappear if inside the disappearing area
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == badarea_0)
        {
            isInTriggerArea = true; // Set the flag when entering the restricted area
            
        }
        else if (other == disappearingArea)
        {
            isInDisappearingArea = true; // Set the flag when entering the disappearing area
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == badarea_0)
        {
            isInTriggerArea = false; // Reset the flag when exiting the restricted area
        }
        else if (other == disappearingArea)
        {
            isInDisappearingArea = false; // Reset the flag when exiting the disappearing area
        }
    }
}
