
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }
}
