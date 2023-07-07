using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int highestScore = 0;
    public string highestUsername;
    public string currentUsername;

    private void Awake()
    {
        //this code allows for the awake method to be only called once
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        //this function will fill up the selectedColor variable at the start of the application
        loadHighScore();
    }

    //data class
    [System.Serializable]
    class SaveData
    {
        public int highestScore;
        public string username;
    }

    //this function should be called in the menuUIhandler script that has accesss to onClick function of the "SaveColor" button. 
    public void saveHighScore()
    {
        SaveData data = new SaveData();
        data.highestScore= this.highestScore;
        data.username = this.highestUsername;

        //this line of encodes the SAVEDATA class instance to a string 
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestUsername = data.username;
            highestScore = data.highestScore;
        }
    }

    public void updateHighScore(int score)
    {
        if (score >= highestScore)
        {
            this.highestScore = score;
            this.highestUsername = currentUsername;
            saveHighScore();
        }
        
    }

    public void StoreCurrentUser(string username)
    {
        this.currentUsername = username;
    }
}
