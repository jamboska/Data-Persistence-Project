using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager instance;

    public string curUserName;
    public int highScorePoints = 0;
    public string highScoreUserName = "";

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();

            curUserName = highScoreUserName;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            SaveData();
        }
    }

    private void SaveData()
    {
        MyData data = new MyData();
        data.highScorePoints = highScorePoints;
        data.highScoreUserName = highScoreUserName;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            MyData data = JsonUtility.FromJson<MyData>(json);

            highScorePoints = data.highScorePoints;
            highScoreUserName = data.highScoreUserName;
        }
    }

    [System.Serializable]
    class MyData
    {
        public int highScorePoints;
        public string highScoreUserName;
    }
}
