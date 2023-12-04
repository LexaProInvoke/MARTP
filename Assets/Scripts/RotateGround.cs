using UnityEngine;

public class RotateGround : MonoBehaviour
{
    public float rotationSpeed = 10f; // скорость вращения

    // Функция FixedUpdate() вызывается с фиксированной частотой, что делает ее хорошим выбором для физики
    void FixedUpdate()
    {
        // Вращение земли вокруг оси Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.fixedDeltaTime);
    }
}