using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    private class UIInfo
    {
        public string uiName;
        public Action showMethod;
        public Action hideMethod;
    }

    private Dictionary<string, UIInfo> uiDictionary;

    // Referenzen 
    [Header("MainMenu")]
    public GameObject mainMenuUI;
    public GameObject mainMenuButtonContainer;
    public Button mainMenuStartButton;
    public Button mainMenuExitButton;

    [Header("HUD")]
    public GameObject hudUI;
    public GameObject actionBar;
    public GameObject infoPanelRightContainer;
    public GameObject coinStatusContainer;
    public GameObject enemyCountContainer;
    public GameObject infoPanelMiddleContainer;
    public TextMeshProUGUI roundCounterText;
    public Button readyButton;
    public GameObject infoPanelLeftContainer;
    public Slider playerHealthBar;
    public TextMeshProUGUI playerHealthBarText;


    [Header("PauseMenu")]
    public GameObject pauseMenuUI;
    public GameObject pauseMenuButtonContainer;
    public Button pauseMenuResumeButton;
    public Button pauseMenuExitButton;

    [Header("GameOverScreen")]
    public GameObject gameOverScreenUI;
    public GameObject gameOverScreenButtonContainer;
    public Button gameOverScreenRetryButton;
    public Button gameOverScreenExitButton;

    [Header("Variables")]
    public bool isMainMenuActive;
    public bool isHUDActive;
    public bool isPauseMenuActive;
    public bool isGameOverScreenActive;

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
        StartingState();

        // Initialisierung des UI-Dictionarys
        uiDictionary = new Dictionary<string, UIInfo>()
        {
            { "MainMenu", new UIInfo { uiName = "MainMenu", showMethod = ShowMainMenuUI, hideMethod = HideMainMenuUI } },
            { "HUD", new UIInfo { uiName = "HUD", showMethod = ShowHUD, hideMethod = HideHUD } },
            { "PauseMenu", new UIInfo { uiName = "PauseMenu", showMethod = ShowPauseMenuUI, hideMethod = HidePauseMenuUI } },
            { "GameOverScreen", new UIInfo { uiName = "GameOverScreen", showMethod = ShowGameOverScreenUI, hideMethod = HideGameOverScreenUI } }
        };
    }

    private void StartingState()
    {
        ShowMainMenuUI();
        HideHUD();
        HidePauseMenuUI();
        HideGameOverScreenUI();
    }

    // Method to display specific UIs per string
    public void ShowUI(string uiName)
    {
        if (uiDictionary.ContainsKey(uiName))
        {
            UIInfo uiInfo = uiDictionary[uiName];
            uiInfo.showMethod.Invoke();
        }
        else
        {
            Debug.LogError("UI with name " + uiName + " not found!");
        }
    }

    // Method to hide specific UIs per string
    public void HideUI(string uiName)
    {
        if (uiDictionary.ContainsKey(uiName))
        {
            UIInfo uiInfo = uiDictionary[uiName];
            uiInfo.hideMethod.Invoke();
        }
        else
        {
            Debug.LogError("UI with name " + uiName + " not found!");
        }
    }

    //SHOW METHODS//
    // Unique Methods to display specific UIs

    private void ShowMainMenuUI()
    {
        isMainMenuActive = true;
        mainMenuUI.SetActive(true);
    }

    private void ShowHUD()
    {
        isHUDActive = true;
        hudUI.SetActive(true);
    }

    private void ShowPauseMenuUI()
    {
        isPauseMenuActive = true;
        pauseMenuUI.SetActive(true);
    }

    private void ShowGameOverScreenUI()
    {
        isGameOverScreenActive = true;
        gameOverScreenUI.SetActive(true);
    }

    //HIDE METHODS//
    // Unique Methods to hide specific UIs

    private void HideMainMenuUI()
    {
        isMainMenuActive = false;
        mainMenuUI.SetActive(false);
    }

    private void HideHUD()
    {
        isHUDActive = false;
        hudUI.SetActive(false);
    }

    private void HidePauseMenuUI()
    {
        isPauseMenuActive = false;
        pauseMenuUI.SetActive(false);
    }

    private void HideGameOverScreenUI()
    {
        isGameOverScreenActive = false;
        gameOverScreenUI.SetActive(false);
    }
}