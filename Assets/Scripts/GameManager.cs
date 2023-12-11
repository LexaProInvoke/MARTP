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
    public GameObject[] allPlayers;

    void Awake()
    {
        if (Manager != null && Manager != this)
        {
            Destroy(gameObject);
        }
        Manager = this;
        DontDestroyOnLoad(gameObject);
        currentZone = 0;
        allPlayers = GameObject.FindGameObjectsWithTag("Player");

    }

    void Start()
    {
        winTextObject.SetActive(false);
        count = 0;
        SetCountText();
        isGameRunning = true;
        SwitchZone(0);
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
            ZoneManager currentZoneManager = Zones[currentZone];

            // pickups--
            currentZoneManager.CollectibleCount--;

            if (currentZoneManager.CollectibleCount <= 0)
            {
                // Obstacle for levels
                // currentZoneManager.Door.SetActive(false); // ??

                currentZone++;
                if (currentZone >= Zones.Count)
                {
                    currentZone = 0; // loop when reached end of zone list
                }

                // TEMP when all pickups are collected - switch to zone 3
                SwitchZone(3);
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

    public void SwitchZone(int newZoneIndex)
    {
        if (newZoneIndex >= 0 && newZoneIndex < Zones.Count)
        {
            currentZone = newZoneIndex;

            foreach (var player in allPlayers)
            {
                var playerController = player.GetComponent<PlayerController>();
                if (playerController.zoneOfPlayer != Zones[currentZone].name)
                {
                    player.SetActive(false);
                }
                else
                {
                    player.SetActive(true);
                }
            }
        }
    }



    /*
    public void SwitchZone(int newZoneIndex)
    {
        Debug.LogError("switch zone func - new " + newZoneIndex);
        if (newZoneIndex >= 0 && newZoneIndex < Zones.Count)
        {
            Debug.LogError("first check yes");
            currentZone = newZoneIndex;

            for (int i = 0; i < Zones.Count; i++)
            {
                if (i != currentZone)
                {
                    Debug.LogError("--------------------------------");

                    ZoneManager zoneManager = Zones[i];
                    GameObject[] playersInZone = zoneManager.GetPlayersInZone(zoneManager.name);
                    Debug.LogError("ZONE NAME TO DESACTIVATE: " + zoneManager.name); 

                    foreach (GameObject player in playersInZone)
                    {
                        Debug.LogError("PLAYER ZONE NAME TO DESACTIVATE: " + player.name);
                        player.SetActive(false); // Деактивируем игроков только в зонах, отличных от текущей
                    }

                    Debug.LogError("--------------------------------");
                }
            }

            // Активация игроков в текущей зоне
            ZoneManager currentZoneManager = Zones[currentZone];
            GameObject[] playersInCurrentZone = currentZoneManager.GetPlayersInZone(currentZoneManager.name);
            Debug.LogError("HERE ___ currentZoneManager.name " + currentZoneManager.name);

            foreach (GameObject player in playersInCurrentZone)
            {
                Debug.LogError("!!! " + player.name);
                player.SetActive(true); // Активируем игроков только в текущей зоне
            }
        }
        else
        {
            Debug.LogError("Invalid zone index!");
        }
    }*/

}


