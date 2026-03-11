using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyManager : MonoBehaviour
{
    private static DontDestroyManager instance;

    [Header("Modules")]
    public GameObject initialModule;
    public GameObject uiModule;
  
    private List<GameObject> objectsToDontDestroy = new List<GameObject>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
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
        DontDestroyObjects();
    }

    private void InitializeReferences()
    {
        if (initialModule == null)
        {
            initialModule = GameObject.Find("InitialModule");
        }

        if (uiModule == null)
        {
            uiModule = GameObject.Find("UIModule");
        }
    }

    private void DontDestroyObjects()
    {
        if (!objectsToDontDestroy.Contains(initialModule) && initialModule != null)
        {
            RegisterObjectToDontDestroy(initialModule);
        }

        if (!objectsToDontDestroy.Contains(uiModule) && uiModule != null)
        {
            RegisterObjectToDontDestroy(uiModule);
        }
    }

    public void RegisterObjectToDontDestroy(GameObject obj)
    {
        DontDestroyOnLoad(obj);
        objectsToDontDestroy.Add(obj);
    }

    public void UnregisterObjectToDontDestroy(GameObject obj)
    {
        if (objectsToDontDestroy.Contains(obj))
        {
            objectsToDontDestroy.Remove(obj);
        }
    }

    public void RemoveGameAndLevelModule()
    {
        GameObject gameModule = GameObject.Find("GameModule");
        GameObject levelModule = GameObject.Find("LevelModule");

        if (gameModule != null)
        {
            UnregisterObjectToDontDestroy(gameModule);
            Destroy(gameModule); 
        }

        if (levelModule != null)
        {
            UnregisterObjectToDontDestroy(levelModule);
            Destroy(levelModule); 
        }
    }
}
