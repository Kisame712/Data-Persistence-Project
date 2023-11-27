using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public Text playerName;
    public Text score;

    private void Awake()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadData();
    }
    [System.Serializable]
    class PlayerData
    {
        public Text playerName;
        public Text score;
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerName = data.playerName;
            score = data.score;
        }

    }
    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.playerName = playerName;
        
        data.score = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
}
