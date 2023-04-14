using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
public class Save
{
    public List<bool> completedLevels;
    public List<int> levelScores;
    public int selectedHat;
}

public class GlobalObject : MonoBehaviour
{
    public static GlobalObject Instance;
    public static Save data;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadData();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        if (!Directory.Exists(Application.persistentDataPath+"Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath+"Saves");

        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "Saves/save.save", json);
    }

    public void LoadData()
    {
        if (!Directory.Exists(Application.persistentDataPath+"Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath+"Saves");

        }
        if (!File.Exists(Application.persistentDataPath+"Saves/save.save")) {
            data = new Save()
            {
                completedLevels = new List<bool>(new bool[30]),
                levelScores = new List<int>(new int[30]),
                selectedHat  = 0
            };
            SaveData();
        }
        string json = File.ReadAllText(Application.persistentDataPath + "Saves/save.save");
        Save s = JsonUtility.FromJson<Save>(json);

        data = s;
    }

    public void ClearData()
    {
        FileStream saveFile = File.Open(Application.persistentDataPath + "Saves/save.save", FileMode.Open);
        data = new Save()
        {
            completedLevels = new List<bool>(new bool[30]),
            levelScores = new List<int>(new int[30]),
            selectedHat = 0
        };
        saveFile.Dispose();
    }
}
