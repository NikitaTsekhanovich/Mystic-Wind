using System;
using LevelsControllers;
using MainMenu;
using PlayerData;
using StoreSkinsContrllers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDataLoader : MonoBehaviour
{
    private StoreSkinData _currentSkinData;
    private LevelData _currentLevelData;

    public static Action OnLoadMenuController;
    public static Action OnLoadStoreSkinsData;
    public static Action OnLoadLevelsData;
    public static Action<StoreSkinData, LevelData> OnInitEcsWorld;
    public static SceneDataLoader Instance;

    private void Awake()
    {
        var objs = GameObject.FindGameObjectsWithTag("SceneDataLoader");

        if (objs.Length > 1)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start() 
    {             
        if (Instance == null) 
        { 
            Instance = this; 
        } 
        else 
        { 
            Destroy(this);  
        } 
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        MenuController.OnStashSkinData += StashCurrentSkinData;
        LevelItem.OnStashLevelData += StashCurrentLevelData;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        MenuController.OnStashSkinData -= StashCurrentSkinData;
        LevelItem.OnStashLevelData -= StashCurrentLevelData;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "Menu")
        {
            CheckFirstLaunch();
            SkinsDataContainer.LoadSkinsData();
            OnLoadMenuController?.Invoke();
            OnLoadStoreSkinsData?.Invoke();
        }
        else if (scene.name == "Levels")
        {
            LevelDataContainer.LoadLevelData();
            OnLoadLevelsData?.Invoke();
        }
        else if (scene.name == "Game")
        {
            OnInitEcsWorld?.Invoke(_currentSkinData, _currentLevelData);
        }
    }

    private void StashCurrentSkinData(StoreSkinData currentSkinData)
    {
        _currentSkinData = currentSkinData;
    }

    private void StashCurrentLevelData(LevelData currentLevelData)
    {
        _currentLevelData = currentLevelData;
    }

    private void CheckFirstLaunch()
    {
        if (PlayerPrefs.GetInt(PlayerDataKeys.IsFirstLaunchGameKey) == (int)TypeLaunch.IsFirst)
        {
            PlayerPrefs.SetInt(PlayerDataKeys.IsFirstLaunchGameKey, (int)TypeLaunch.IsNotFirst);
            PlayerPrefs.SetInt($"{StateStoreItemDataKeys.StateItemKey}{0}", (int)TypeStateStoreItem.Selected);
            PlayerPrefs.SetInt(StateStoreItemDataKeys.IndexChosenItemKey, 0);
            PlayerPrefs.SetInt($"{LevelDataKeys.LevelOpenKey}{0}", (int)TypeStateObject.IsOpen);
        }
    }
}
