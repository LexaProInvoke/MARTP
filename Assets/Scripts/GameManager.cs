using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    // Start is called before the first frame update
    public void Awake()
    {
        if (GameManager.Manager != null)
        {
            Destroy(this);
        }
        Manager = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
