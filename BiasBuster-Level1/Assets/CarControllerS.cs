using UnityEngine;

public class CarController : MonoBehaviour
{
    public float forwardSpeed = 10f; // Constant forward speed
    public float laneDistance = 3f; // Distance between lanes
    private int currentLane = 0;    // Current lane index (-1 = left, 0 = center, 1 = right)

    private Vector3 targetPosition;

    void Start()
    {
        // Set initial position to the center lane
        targetPosition = transform.position;
    }

    void Update()
    {
        // Move forward at a constant speed
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Check for lane switch input
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangeLane(-1); // Move left
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeLane(1); // Move right
        }

        // Smoothly move the car to the target lane position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
    }

    void ChangeLane(int direction)
    {
        // Calculate the new lane index
        int newLane = Mathf.Clamp(currentLane + direction, -1, 1);

        // Update the target position only if the lane changes
        if (newLane != currentLane)
        {
            currentLane = newLane;
            targetPosition = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);
        }
    }
}
