using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private static SceneLoadManager instance;

    [Header("References")]
    public InitializeSystem init;

    [Header("Variables")]
    public bool isInitialBootrstrapLoaded;
    public bool isMainMenuLoaded;
    public bool isGameBootstrapLoaded;
    public bool isLevel_01Loaded;

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
        isMainMenuLoaded = true;
    }

    public void LoadInitialBootstrap()
    {
        SceneManager.LoadScene("InitialBootstrap");
        isInitialBootrstrapLoaded = true;
        isMainMenuLoaded = false;
        isGameBootstrapLoaded = false;
        isLevel_01Loaded = false;
    }

    public void LoadMainMenu()
    {
        InitializeGameSystem initGame = FindObjectOfType<InitializeGameSystem>();
        init.dontDestroyManager.RemoveGameAndLevelModule();

        SceneManager.LoadScene("MainMenu");
        init.uiManager.ShowUI("MainMenu");
        init.uiManager.HideUI("HUD");
        init.uiManager.HideUI("PauseMenu");
        init.uiManager.HideUI("GameOverScreen");

        isInitialBootrstrapLoaded = false;
        isMainMenuLoaded = true;
        isGameBootstrapLoaded = false;
        isLevel_01Loaded = false;

        Debug.Log("Loading Main Menu: isMainMenuLoaded = " + isMainMenuLoaded);
    }

    public void LoadGameBootstrap()
    {
        init.dontDestroyManager.RemoveGameAndLevelModule();

        SceneManager.LoadScene("GameBootstrap");
        init.uiManager.HideUI("MainMenu");
        init.uiManager.ShowUI("HUD");
        init.uiManager.HideUI("PauseMenu");
        init.uiManager.HideUI("GameOverScreen");

        isInitialBootrstrapLoaded = false;
        isMainMenuLoaded = false;
        isGameBootstrapLoaded = true;
        isLevel_01Loaded = false;
    }

    public void LoadLevel_01()
    {
        InitializeGameSystem initGame = FindObjectOfType<InitializeGameSystem>();

        SceneManager.LoadScene("Level_01");
        init.uiManager.HideUI("MainMenu");
        init.uiManager.ShowUI("HUD");
        init.uiManager.HideUI("PauseMenu");
        init.uiManager.HideUI("GameOverScreen");

        isInitialBootrstrapLoaded = false;
        isMainMenuLoaded = false;
        isGameBootstrapLoaded = false;
        isLevel_01Loaded = true;

        Time.timeScale = 1f;
        Debug.Log("Loading Level 01: isLevel_01Loaded = " + isLevel_01Loaded);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
