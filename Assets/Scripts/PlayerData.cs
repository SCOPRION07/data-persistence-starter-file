using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string playerName;
   
    public string bestplayer;
    public int bestScore;
    
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }
    public void SaveScore() // serialization of data 
    {
        SaveData data = new SaveData();
        data.playerName = bestplayer;
        data.score = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore()// deserialization of data 
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestplayer = data.playerName ;
            bestScore = data.score;
            
        }
    }

}
