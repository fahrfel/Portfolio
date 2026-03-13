using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListenerManager : MonoBehaviour
{
    private static ButtonListenerManager instance;

    [Header("References")]
    public InitializeSystem init;

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
        StartingState();
    }

    private void InitializeReferences()
    {
        if (init == null)
        {
            init = FindObjectOfType<InitializeSystem>();
        }
    }

    private void StartingState()
    {
        InitializeMainMenuButtons();
        InitializeHUDButtons();
        InitializePauseMenuButtons();
    }

    private void InitializeMainMenuButtons()
    {
        if (init.uiManager.mainMenuStartButton != null)
        {
            init.uiManager.mainMenuStartButton.onClick.RemoveAllListeners();
            init.uiManager.mainMenuStartButton.onClick.AddListener(init.sceneLoadManager.LoadGameBootstrap);
        }

        if (init.uiManager.mainMenuExitButton != null)
        {
            init.uiManager.mainMenuExitButton.onClick.RemoveAllListeners();
            init.uiManager.mainMenuExitButton.onClick.AddListener(init.sceneLoadManager.CloseGame);

        }
    }

    private void InitializeHUDButtons()
    {
        if (init.uiManager.readyButton != null)
        {
            init.uiManager.readyButton.onClick.RemoveAllListeners();
        }
    }

    private void InitializePauseMenuButtons()
    {
        if (init.uiManager.pauseMenuResumeButton != null)
        {
            init.uiManager.pauseMenuResumeButton.onClick.RemoveAllListeners();
            init.uiManager.pauseMenuResumeButton.onClick.AddListener(init.inputManager.ResumeButtonClicked);
        }

        if (init.uiManager.pauseMenuExitButton != null)
        {
            init.uiManager.pauseMenuExitButton.onClick.RemoveAllListeners();
            init.uiManager.pauseMenuExitButton.onClick.AddListener(init.sceneLoadManager.LoadMainMenu);
        }
    }  
}
