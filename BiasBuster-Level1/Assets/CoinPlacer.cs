// using UnityEngine;

// public class RandomCoinPlacer : MonoBehaviour
// {
//     public GameObject coinType1; 
//     public GameObject coinType2; 
//     public Transform road;       
//     public int numberOfCoins = 20; 
//     public float spacing = 1f;  

//     void Start()
//     {
//         PlaceCoinsRandomly();
//     }

//     void PlaceCoinsRandomly()
//     {
//         if (coinType1 == null || coinType2 == null || road == null)
//         {
//             Debug.LogError("One or more required references (coinType1, coinType2, or road) are not assigned!");
//             return;
//         }

//         Vector3 roadStart = road.position - (road.forward * (road.localScale.z / 2));
//         Vector3 roadEnd = road.position + (road.forward * (road.localScale.z / 2));

//         for (int i = 0; i < numberOfCoins; i++)
//         {
           
//             GameObject selectedCoin = Random.value > 0.5f ? coinType1 : coinType2;

//             float t = Random.Range(0f, 1f); 
//             Vector3 position = Vector3.Lerp(roadStart, roadEnd, t);
//             float lateralOffset = Random.Range(-road.localScale.x / 2 + 0.5f, road.localScale.x / 2 - 0.5f);
//             position += road.right * lateralOffset;
//             position.y += 0.5f;
//             Instantiate(selectedCoin, position, Quaternion.identity);
//         }
//     }
// }
using UnityEngine;

public class RandomCoinPlacer : MonoBehaviour
{
    public GameObject coinType1; // First type of coin prefab
    public GameObject coinType2; // Second type of coin prefab
    public Transform road;       // Road object
    public int numberOfCoins = 20; // Total number of coins to place
    public Vector3 minBounds;    // Minimum (x, z) bounds for placement
    public Vector3 maxBounds;    // Maximum (x, z) bounds for placement

    public float raycastHeightOffset = 10f; // Height above the road to cast the ray
    public LayerMask roadLayer; // Layer mask for the road to ensure we hit it

    void Start()
    {
        PlaceCoinsOnRoad();
    }

    void PlaceCoinsOnRoad()
    {
        if (coinType1 == null || coinType2 == null || road == null)
        {
            Debug.LogError("One or more required references (coinType1, coinType2, or road) are not assigned!");
            return;
        }

        for (int i = 0; i < numberOfCoins; i++)
        {
            
            GameObject selectedCoin = Random.value > 0.5f ? coinType1 : coinType2;

            float x = Random.Range(minBounds.x, maxBounds.x);
            float z = Random.Range(minBounds.z, maxBounds.z);
            Vector3 rayOrigin = new Vector3(x, maxBounds.y + raycastHeightOffset, z);

            // Perform a raycast downward to find the road's surface
            if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, Mathf.Infinity, roadLayer))
            {
                // Set the position to the hit point on the road
                Vector3 position = hit.point;
                position.y += 1.2f;

                // Instantiate the coin at the calculated position
                Instantiate(selectedCoin, position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning($"Raycast did not hit the road at position {rayOrigin}. Check your bounds or road layer.");
            }
        }
    }
}
