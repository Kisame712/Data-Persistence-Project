using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class LoadBest : MonoBehaviour
{
    // Start is called before the first frame update
    private Text BestPlarNameAndScore;
    class SaveData
    {
        public int highestScore;
        public string theBestPlayer;
    }
    private void Awake()
    {
        BestPlarNameAndScore = GetComponent<Text>();
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlarNameAndScore.text = $"Best Score : {data.theBestPlayer}: {data.highestScore}";
        }
    }
}
