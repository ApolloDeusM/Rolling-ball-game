using System.IO;
using UnityEngine;
using System.Collections;
using TMPro;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int topscore;
    public int currentLevel;

}

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    private string savePath;

    public PlayerData playerData = new PlayerData();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this across scenes
            savePath = Application.persistentDataPath + "/gameData.json";
            LoadData(); // Load saved data on start
        }
        else
        {
            Destroy(gameObject);
        }
    
    }
    void Start()
    {
       /* while(playerData.coins > 0)
        {
            playerData.coins--;
            Debug.Log(playerData.coins);
            SaveData();
        }*/
    }
    void Update()
    {
        
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(playerData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Game Data Saved: " + json);
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            Debug.Log("Game Data Loaded: " + json);
        }
        else
        {
            Debug.LogWarning("No save file found, initializing new data.");
            playerData = new PlayerData { coins = 9, topscore  = 0, currentLevel = 1 }; // Default values
            SaveData();
        }
    }

    public void UpdateCoins(int amount)
    {
        playerData.coins += amount;
        SaveData();
    }

    public void toNextLevel()
    {
        playerData.currentLevel++;
        SaveData();
    }

    public void UpdateTopScore(int value)
    {
        playerData.topscore += value;
        SaveData();
    }
   
    
}