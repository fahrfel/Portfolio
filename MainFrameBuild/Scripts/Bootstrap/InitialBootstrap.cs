using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialBootstrap : MonoBehaviour
{
    private static InitialBootstrap instance;

    [Header("Modules")]
    public GameObject initialModule;
    public GameObject uiModule;
   
    private static bool modulesInitialized = false;

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
        if (!modulesInitialized)
        {
            LoadModules();   
            modulesInitialized = true;  
        }

        StartCoroutine(LoadSceneAsync("MainMenu"));
    }

    private void LoadModules()
    {
        if (initialModule != null)
        {
            Debug.Log("Instantiating Initial Module...");
            GameObject instance = Instantiate(initialModule);
            instance.name = initialModule.name;
            Debug.Log("Initial Module instantiated successfully.");
        }
        else
        {
            Debug.LogError("Initial Module reference is missing!");
        }

        if (uiModule != null)
        {
            Debug.Log("Instantiating UI Module...");
            GameObject instance = Instantiate(uiModule);
            instance.name = uiModule.name;
            Debug.Log("UI Module instantiated successfully.");
        }
        else
        {
            Debug.LogError("UI Module reference is missing!");
        }       
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
