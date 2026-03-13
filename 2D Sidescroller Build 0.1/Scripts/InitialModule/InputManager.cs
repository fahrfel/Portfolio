using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    [Header("References")]
    public InitializeSystem init;

    [Header("Variables")]
    public bool isPaused;

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
        InitializeReferences();
    }

    private void Update()
    {
        TogglePauseMenu();
    }

    private void InitializeReferences()
    {
        if (init == null)
        {
            init = FindObjectOfType<InitializeSystem>();
        }
    }

    public void ResumeButtonClicked()
    {
        init.uiManager.HideUI("PauseMenu");
        init.uiManager.ShowUI("HUD");
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void TogglePauseMenu()
    {
        if (init != null && init.sceneLoadManager.isMainMenuLoaded)
        {
            return;
        }
        else if (init != null && init.sceneLoadManager.isLevel_01Loaded)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (init.uiManager.isPauseMenuActive)
                {
                    init.uiManager.HideUI("PauseMenu");
                    init.uiManager.ShowUI("HUD");
                    Time.timeScale = 1f;
                    isPaused = false;

                }
                else
                {
                    init.uiManager.ShowUI("PauseMenu");
                    init.uiManager.HideUI("HUD");
                    Time.timeScale = 0f;
                    isPaused = true;
                }
            }
        }      
    }
}
