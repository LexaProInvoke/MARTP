using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        if (player != null)
            offset = transform.position - player.transform.position;
        else
            Debug.LogError("Player GameObject is not assigned to the Camera Controller!");
    }

    void LateUpdate()
    {
        if (player != null)
            transform.position = player.transform.position + offset;
    }
}
