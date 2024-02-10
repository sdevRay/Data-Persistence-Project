using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    public SaveData TopScore;
    public string CurrentPlayerName;
    public int CurrentScore;
	private void Awake()
	{
		Debug.Log(Application.persistentDataPath);

		if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
	}

    [Serializable]
    public class SaveData
    {
        public string Name;
        public int Score;
    }

	public void SaveScore()
	{
		var saveData = new SaveData() { Name = CurrentPlayerName, Score = CurrentScore };
        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
	}

    public void LoadScore()
    {
        var path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path)) 
        { 
            var json = File.ReadAllText(path);
		    var obj = JsonUtility.FromJson<SaveData>(json);
            TopScore = obj;
		}
    }
}
