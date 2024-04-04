using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public GameObject wallPrefab;  // Prefab for walls

    public float squareLength = 10f;  // Length of one side of the square room

    void Start()
    {
        CreateRoom(squareLength);
    }

    void CreateRoom(float length)
    {
        // Calculate half of the room dimensions
        float halfLength = length / 2f;

        // Create walls
        CreateWall(new Vector3(0f, wallPrefab.transform.position.y, halfLength), Quaternion.identity, length);  // Top wall
        CreateWall(new Vector3(0f, wallPrefab.transform.position.y, -halfLength), Quaternion.identity, length); // Bottom wall
        CreateWall(new Vector3(-halfLength, wallPrefab.transform.position.y, 0), Quaternion.Euler(0f, 90f, 0f), length);  // Left wall
        CreateWall(new Vector3(halfLength, wallPrefab.transform.position.y, 0), Quaternion.Euler(0f, 90f, 0f), length);   // Right wall

        // Ceiling (using wallPrefab)
        GameObject ceiling = Instantiate(wallPrefab, new Vector3(0f, halfLength - 1, 0f), Quaternion.Euler(90f, 0f, 0f));
        ceiling.transform.localScale = new Vector3(length, length, wallPrefab.transform.localScale.z);
    }

    void CreateWall(Vector3 position, Quaternion rotation, float length)
    {
        GameObject wall = Instantiate(wallPrefab, position, rotation);
        wall.transform.localScale = new Vector3(length, length, wallPrefab.transform.localScale.z);
    }
}
