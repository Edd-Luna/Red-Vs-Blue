using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MainManager : MonoBehaviour
{
 public static MainManager Instance { get; private set; }// add private ENCAPSULATION
 public int redPlayer;
 public int bluePlayer;
 public int redScore;
 public int blueScore;
 public int gameCount;

 private void Awake()
 {
    if (Instance != null)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;
    DontDestroyOnLoad(gameObject);
    LoadColorPlayer();
 }

[System.Serializable]
    class SaveData
    {

    public int redPlayer;
    public int bluePlayer;
    public int redScore;
    public int blueScore;

    }

    public void SaveColorPlayer( int redPlayer, int bluePlayer)
    {
    SaveData data = new SaveData();
    data.redPlayer = redPlayer;
    data.bluePlayer = bluePlayer;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColorPlayer()
    {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        redPlayer = data.redPlayer;
        bluePlayer = data.bluePlayer;
    }
    }

    public void SaveScores(int redScore, int blueScore)
    {
    SaveData data = new SaveData();
    data.redScore = redScore;
    data.blueScore = blueScore;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    
    public void LoadScores()
    {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        redScore = data.redScore;
        blueScore = data.blueScore;
    }
    }

}
