using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    public GameObject winTextObject;
    private int count;
    private float currentTime = 0f;
    private bool isGameRunning = false;
    public List<ZoneManager> Zones;
    public int currentZone;

    void Awake()
    {
        if (Manager != null && Manager != this)
        {
            Destroy(gameObject);
        }
        Manager = this;
        DontDestroyOnLoad(gameObject);
        // Zones = new List<ZoneManager>();
        currentZone = 0;
    }

    void Start()
    {
        winTextObject.SetActive(false);
        count = 0;
        SetCountText();
        isGameRunning = true;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            isGameRunning = false;
        }
    }

    void Update()
    {
        if (isGameRunning)
        {
            // timer update
            currentTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // time display MM:SS
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    public void Collect(GameObject gameObject)
    {
        if (currentZone >= 0 && currentZone < Zones.Count) // Проверка на допустимый диапазон
        {
            // Получение текущего ZoneManager из списка Zones
            ZoneManager currentZoneManager = Zones[currentZone];

            // Уменьшение количества объектов для сбора в текущей зоне
            currentZoneManager.CollectibleCount--;

            // Проверка, достигнут ли ноль объектов для сбора в текущей зоне
            if (currentZoneManager.CollectibleCount <= 0)
            {
                // Отключение двери/препятствия текущей зоны
                // currentZoneManager.Door.SetActive(false); ??

                // Увеличение текущей зоны
                currentZone++;
                // Проверка, чтобы избежать выхода за пределы списка Zones
                if (currentZone >= Zones.Count)
                {
                    currentZone = 0; // Возврат к первой зоне, если достигнут конец списка
                }
            }

            count += 1;
            SetCountText();
            Debug.LogError("Pickups left" + currentZoneManager.CollectibleCount + ".");

        }
        else
        {
            Debug.LogError("Invalid currentZone index or Zones list is empty.");
        }
        Debug.LogError("Current zone = " + currentZone + ".");


    }

}


