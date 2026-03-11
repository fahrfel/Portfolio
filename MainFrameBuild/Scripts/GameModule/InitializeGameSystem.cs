using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InitializeGameSystem : MonoBehaviour
{
    private static InitializeGameSystem instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        InitializeSystems();
        InitializeManager();
    }

    private void InitializeSystems()
    {
        Debug.Log("Initializing Systems...");
        Debug.Log("Systems Initialized!");
    }

    private void InitializeManager()
    {
        Debug.Log("Initializing Manager...");
        Debug.Log("Manager Initialized!");
    }
}
