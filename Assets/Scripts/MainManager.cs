using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class MainManager : MonoBehaviour
{
 public static MainManager Instance;
 public int redPlayer;
 public int bluePlayer;

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
}
