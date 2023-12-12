using UnityEngine;
using UnityEngine.Events;

public class BulletFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public int BulletZone = 0; // Зона для пули

    void Start()
    {
        GameManager.Manager.OnNextZone.AddListener(OnChangeZone);
    }

    void Update()
    {
        // Проверяем, если пуля в своей зоне, активируем перемещение
        if (GameManager.Manager.currentZone == BulletZone && player != null)
        {
            Vector3 targetPosition = player.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }

    // Функция вызывается при изменении зоны
    public void OnChangeZone(int newZone)
    {
        // Проверяем, соответствует ли новая зона зоне пули
        if (newZone == BulletZone)
        {
            // Активируем перемещение пули
            Debug.Log("Пуля в своей зоне, активация перемещения!");
            // Здесь можно добавить другие действия при нахождении пули в своей зоне
        }
    }
}
