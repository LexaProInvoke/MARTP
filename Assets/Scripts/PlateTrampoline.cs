using System.Collections;
using UnityEngine;

public class PlateTrampoline : MonoBehaviour
{
    public float jumpForce = 10f; // ���� ������ ����� ������������ � ����������
    public float duration = 2f; // ����������������� ����������� �������� ����� ������������

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody playerRB = other.GetComponent<Rigidbody>();
            if (playerRB != null)
            {
                Jump(playerRB);
            }
        }
    }

    void Jump(Rigidbody rb)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

   
}
