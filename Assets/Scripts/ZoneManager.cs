using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public int CollectibleCount = 0; // number of pickups for each zone
    public GameObject Door; // obstacle to desactivate after finishing the zone 

    void Start()
    {
    }

    /*
    public GameObject[] GetPlayersInAllZones()
    {
        return GameObject.FindGameObjectsWithTag("Player"); // tag "Player"
    }

    public GameObject[] GetPlayersInZone(string zone)
    {
        // Находим игроков только в зоне с указанным тегом
        GameObject[] playersInZone = GameObject.FindGameObjectsWithTag("Player");

        // Фильтруем найденных игроков по тегу зоны
        List<GameObject> playersInSpecificZone = new List<GameObject>();
        foreach (GameObject player in playersInZone)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null && playerController.zoneOfPlayer == zone)
            {
                playersInSpecificZone.Add(player);
            }
        }

        return playersInSpecificZone.ToArray();
    }
    */

}
