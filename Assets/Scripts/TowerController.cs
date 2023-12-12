using System.Collections;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public float ReloadTime;
    public GameObject Bullet;
    public float ShootSpeed = 0.9f;
    private float totalRotation = 85f; // Общее вращение
    public float rotationSpeed = 50f; // Скорость вращения
    private bool rotateClockwise = true; // Направление вращения (по часовой стрелке)
    private float currentRotation = 0f; // Текущий угол вращения

    public IEnumerator ShootCoroutine(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            CreateBullet();
        }
    }

    private void CreateBullet()
    {
        GameObject newBullet = Instantiate(Bullet, transform.position + (transform.right * 0.6f), Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.right * ShootSpeed, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if (rotateClockwise)
        {
            RotateClockwise();
        }
        else
        {
            RotateCounterClockwise();
        }
    }

    void RotateClockwise()
    {
        if (currentRotation < totalRotation)
        {
            float rotationAmount = rotationSpeed * Time.fixedDeltaTime;
            if (currentRotation + rotationAmount > totalRotation)
            {
                rotationAmount = totalRotation - currentRotation;
            }
            transform.Rotate(Vector3.up, rotationAmount);
            currentRotation += rotationAmount;
        }
        else
        {
            rotateClockwise = false;
        }
    }

    void RotateCounterClockwise()
    {
        if (currentRotation > -totalRotation)
        {
            float rotationAmount = rotationSpeed * Time.fixedDeltaTime;
            if (currentRotation - rotationAmount < -totalRotation)
            {
                rotationAmount = currentRotation + totalRotation;
            }
            transform.Rotate(Vector3.up, -rotationAmount);
            currentRotation -= rotationAmount;
        }
        else
        {
            rotateClockwise = true;
        }
    }

    void Start()
    {
        StartCoroutine(ShootCoroutine(ReloadTime));
    }

    void Update()
    {
        // Дополнительные действия при обновлении кадра, если необходимо
    }
}
