using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float jumpForce = 10f;
    public string zoneOfPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // When player moves
    void OnMove(InputValue movementValue)
    {
        // movementValue - predifined system variable
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY= movementVector.y;
    }

    // Each fixed period of time - for physics
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // Collide with the pick ups
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            if (GameManager.Manager != null)
            {
                GameManager.Manager.Collect(other.gameObject);
            }
            else
            {
                Debug.LogError("GameManager is not initialized!");
            }
        }
    }

    public void OnJump(InputValue jumpValue)
    {
        // Проверка наличия Rigidbody у игрока
        if (rb != null)
        {
            // Придаем импульс для прыжка по вертикальной оси (ось Y)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Rigidbody component not found on the player!");
        }
    }

    public void GotHit()
    {
        GameManager.Manager.RestartGame(); 
    }


}
