using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InitializeSystem : MonoBehaviour
{
    private static InitializeSystem instance;

    //[Header("Manager")]
    public RefManagerUI refManagerUI;
    public UIManager uiManager;
    public DontDestroyManager dontDestroyManager;
    public SceneLoadManager sceneLoadManager;
    public InputManager inputManager;


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
        InitializeManager();
    }

    private void InitializeManager()
    {
        Debug.Log("Initializing Manager...");

        if (refManagerUI == null)
        {
            Debug.Log("Looking for RefManagerUI...");
            refManagerUI = FindObjectOfType<RefManagerUI>();

            if (refManagerUI != null)
            {
                Debug.Log("RefManagerUI Found!");
                Debug.Log("Initializing RefManagerUI...");
            }
            else
            {
                Debug.Log("RefManagerUI Not Found!");
            }

            Debug.Log("RefManagerUI Initialized!");
        }

        if (uiManager == null)
        {
            Debug.Log("Looking for UIManager...");
            uiManager = FindObjectOfType<UIManager>();

            if (uiManager != null)
            {
                Debug.Log("UIManager Found!");
                Debug.Log("Initializing UIManager...");

                if (refManagerUI != null)
                {
                    refManagerUI.InitializeUIReferences();
                }
            }
            else
            {
                Debug.Log("UIManager Not Found!");
            }

            Debug.Log("UIManager Initialized!");
        }

        if (dontDestroyManager == null)
        {
            Debug.Log("Looking for DontDestroyManager...");
            dontDestroyManager = FindObjectOfType<DontDestroyManager>();
            if (dontDestroyManager != null)
            {
                Debug.Log("DontDestroyManager Found!");
                Debug.Log("Initializing DontDestroyManager...");
            }
            else
            {
                Debug.Log("DontDestroyManager Not Found!");
            }
            Debug.Log("DontDestroyManager Initialized!");
        }

        if (sceneLoadManager == null)
        {
            Debug.Log("Looking for SceneLoadManager...");
            sceneLoadManager = FindObjectOfType<SceneLoadManager>();
            if (sceneLoadManager != null)
            {
                Debug.Log("SceneLoadManager Found!");
                Debug.Log("Initializing SceneLoadManager...");
            }
            else
            {
                Debug.Log("SceneLoadManager Not Found!");
            }
            Debug.Log("SceneLoadManager Initialized!");
        }

        if (inputManager == null)
        {
            Debug.Log("Looking for InputManager...");
            inputManager = FindObjectOfType<InputManager>();
            if (inputManager != null)
            {
                Debug.Log("InputManager Found!");
                Debug.Log("Initializing InputManager...");
            }
            else
            {
                Debug.Log("InputManager Not Found!");
            }
        }

        Debug.Log("Manager Initialized!");
    }   
}
