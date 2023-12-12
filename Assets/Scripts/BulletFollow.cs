using UnityEngine;
using UnityEngine.Events;

public class BulletFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public int BulletZone = 0; // ���� ��� ����

    void Start()
    {
        GameManager.Manager.OnNextZone.AddListener(OnChangeZone);
    }

    void Update()
    {
        // ���������, ���� ���� � ����� ����, ���������� �����������
        if (GameManager.Manager.currentZone == BulletZone && player != null)
        {
            Vector3 targetPosition = player.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    // ������� ���������� ��� ��������� ����
    public void OnChangeZone(int newZone)
    {
        // ���������, ������������� �� ����� ���� ���� ����
        if (newZone == BulletZone)
        {
            // ���������� ����������� ����
            Debug.Log("���� � ����� ����, ��������� �����������!");
            // ����� ����� �������� ������ �������� ��� ���������� ���� � ����� ����
        }
    }
}
