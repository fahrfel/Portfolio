using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    private static GameBootstrap instance;

    [Header("References")]
    public InitializeSystem init;

    [Header("Modules")]
    public GameObject levelModule;
    public GameObject gameModule;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            InitializeReferences();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        LoadModules(); // Lade Module immer neu, wenn GameBootstrap startet
        init.sceneLoadManager.LoadLevel_01();
    }

    private void InitializeReferences()
    {
        if (init == null)
        {
            init = FindObjectOfType<InitializeSystem>();
        }
    }

    private void LoadModules()
    {
        if (levelModule != null)
        {
            Debug.Log("Instantiating Level Module...");
            GameObject instance = Instantiate(levelModule);
            instance.name = levelModule.name;
            DontDestroyManager dontDestroyManager = FindObjectOfType<DontDestroyManager>();

            if (dontDestroyManager != null)
            {
                dontDestroyManager.RegisterObjectToDontDestroy(instance);
            }

            Debug.Log("Level Module instantiated successfully.");
        }
        else
        {
            Debug.LogError("Level Module reference is missing!");
        }

        if (gameModule != null)
        {
            Debug.Log("Instantiating Game Module...");
            GameObject instance = Instantiate(gameModule);
            instance.name = gameModule.name;
            DontDestroyManager dontDestroyManager = FindObjectOfType<DontDestroyManager>();

            if (dontDestroyManager != null)
            {
                dontDestroyManager.RegisterObjectToDontDestroy(instance);
            }

            Debug.Log("Game Module instantiated successfully.");
        }
        else
        {
            Debug.LogError("Game Module reference is missing!");
        }
    }
}
