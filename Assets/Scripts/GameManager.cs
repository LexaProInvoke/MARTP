/*
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;

    public void Awake()
    {
        if (GameManager.Manager != null)
        {
            Destroy(this);
        }
        Manager = this;
        DontDestroyOnLoad(gameObject); // ?
    }

    void Start()
    {
        winTextObject.SetActive(false);
        count = 0;
        SetCountText();


    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    public void Collect(GameObject gameObject)
    {
        count += 1;
        SetCountText();
    }

    void Update()
    {
        
    }
}
*/


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

    void Awake()
    {
        if (Manager != null && Manager != this)
        {
            Destroy(gameObject);
        }
        Manager = this;
        DontDestroyOnLoad(gameObject);
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
        count += 1;
        SetCountText();
    }
}
