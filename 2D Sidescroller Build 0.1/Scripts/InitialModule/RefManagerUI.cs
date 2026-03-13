using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RefManagerUI : MonoBehaviour
{
    private static RefManagerUI instance;

    [Header("Refernces")]
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

        InitializeReferences();
    }

    private void InitializeReferences()
    {
        if (init == null)
        {
            init = FindObjectOfType<InitializeSystem>();
        }
    }

    public void InitializeUIReferences()
    {
        SetMainMenuUIReferences();
        SetHUDUIReferences();
        SetPauseMenuUIReferences();
        SetGameOverScreenUIReferences();
    }

    private void SetMainMenuUIReferences()
    {
        if (init.uiManager.mainMenuUI == null)
        {
            init.uiManager.mainMenuUI = GameObject.Find("UI: MainMenu");
        }

        if (init.uiManager.mainMenuButtonContainer == null)
        {
            init.uiManager.mainMenuButtonContainer = GameObject.Find("MainMenuButtonContainer");
        }

        if (init.uiManager.mainMenuStartButton == null)
        {
            Transform buttonTransform = init.uiManager.mainMenuButtonContainer.transform.Find("ContainerBackground/StartButton");

            if (buttonTransform != null)
            {
                init.uiManager.mainMenuStartButton = buttonTransform.GetComponent<Button>();
            }
        }

        if (init.uiManager.mainMenuExitButton == null)
        {
            Transform buttonTransform = init.uiManager.mainMenuButtonContainer.transform.Find("ContainerBackground/ExitButton");

            if (buttonTransform != null)
            {
                init.uiManager.mainMenuExitButton = buttonTransform.GetComponent<Button>();
            }
        }
    }

    private void SetHUDUIReferences()
    {
        if (init.uiManager.hudUI == null)
        {
            init.uiManager.hudUI = GameObject.Find("UI: HUD");
        }

        if (init.uiManager.actionBar == null)
        {
            init.uiManager.actionBar = GameObject.Find("ActionBar");
        }

        if (init.uiManager.infoPanelRightContainer == null)
        {
            init.uiManager.infoPanelRightContainer = GameObject.Find("InfoPanelRightContainer");
        }

        if (init.uiManager.coinStatusContainer == null)
        {
            init.uiManager.coinStatusContainer = GameObject.Find("CoinStatusContainer");
        }

        if (init.uiManager.enemyCountContainer == null)
        {
            init.uiManager.enemyCountContainer = GameObject.Find("EnemyCountContainer");
        }

        if (init.uiManager.infoPanelMiddleContainer == null)
        {
            init.uiManager.infoPanelMiddleContainer = GameObject.Find("InfoPanelMiddleContainer");
        }

        if (init.uiManager.roundCounterText == null)
        {
            Transform textTransform = init.uiManager.infoPanelMiddleContainer.transform.Find("RoundCounterText");

            if (textTransform != null)
            {
                init.uiManager.roundCounterText = textTransform.GetComponent<TextMeshProUGUI>();
            }
        }

        if (init.uiManager.readyButton == null)
        {
            Transform buttonTransform = init.uiManager.infoPanelMiddleContainer.transform.Find("ReadyButton");

            if (buttonTransform != null)
            {
                init.uiManager.readyButton = buttonTransform.GetComponent<Button>();
            }
        }

        if (init.uiManager.infoPanelLeftContainer == null)
        {
            init.uiManager.infoPanelLeftContainer = GameObject.Find("InfoPanelLeftContainer");
        }

        if (init.uiManager.playerHealthBar == null)
        {
            Transform sliderTransform = init.uiManager.infoPanelLeftContainer.transform.Find("PlayerHealthBar");

            if (sliderTransform != null)
            {
                init.uiManager.playerHealthBar = sliderTransform.GetComponent<Slider>();
            }
        }

        if (init.uiManager.playerHealthBarText == null)
        {
            Transform textTransform = init.uiManager.playerHealthBar.transform.Find("PlayerHealthBarText");

            if (textTransform != null)
            {
                init.uiManager.playerHealthBarText = textTransform.GetComponent<TextMeshProUGUI>();
            }
        }
    }

    private void SetPauseMenuUIReferences()
    {
        if (init.uiManager.pauseMenuUI == null)
        {
            init.uiManager.pauseMenuUI = GameObject.Find("UI: PauseMenu");
        }

        if (init.uiManager.pauseMenuButtonContainer == null)
        {
            init.uiManager.pauseMenuButtonContainer = GameObject.Find("PauseMenuButtonContainer");
        }

        if (init.uiManager.pauseMenuResumeButton == null)
        {
            Transform buttonTransform = init.uiManager.pauseMenuButtonContainer.transform.Find("ResumeButton");

            if (buttonTransform != null)
            {
                init.uiManager.pauseMenuResumeButton = buttonTransform.GetComponent<Button>();
            }
        }

        if (init.uiManager.pauseMenuExitButton == null)
        {
            Transform buttonTransform = init.uiManager.pauseMenuButtonContainer.transform.Find("ExitButton");

            if (buttonTransform != null)
            {
                init.uiManager.pauseMenuExitButton = buttonTransform.GetComponent<Button>();
            }
        }
    }

    private void SetGameOverScreenUIReferences()
    {
        if (init.uiManager.gameOverScreenUI == null)
        {
            init.uiManager.gameOverScreenUI = GameObject.Find("UI: GameOverScreen");
        }

        if (init.uiManager.gameOverScreenButtonContainer == null)
        {
            init.uiManager.gameOverScreenButtonContainer = GameObject.Find("GameOverScreenButtonContainer");
        }

        if (init.uiManager.gameOverScreenRetryButton == null)
        {
            Transform buttonTransform = init.uiManager.gameOverScreenButtonContainer.transform.Find("RetryButton");

            if (buttonTransform != null)
            {
                init.uiManager.gameOverScreenRetryButton = buttonTransform.GetComponent<Button>();
            }
        }

        if (init.uiManager.gameOverScreenExitButton == null)
        {
            Transform buttonTransform = init.uiManager.gameOverScreenButtonContainer.transform.Find("ExitToMenuButton");

            if (buttonTransform != null)
            {
                init.uiManager.gameOverScreenExitButton = buttonTransform.GetComponent<Button>();
            }
        }
    }
}
