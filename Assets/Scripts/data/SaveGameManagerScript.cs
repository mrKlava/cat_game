using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "SaveGameManagerScript", menuName = "Scriptable Objects/SaveGameManagerScript")]
public class SaveGameManagerScript : ScriptableObject
{
    // name of file were game data is stored
    private string fileName = "/savefile.json";

    public GameDataScript SaveGame(GameDataScript data)
    {
        // create an JSON from passed data 
        string json = JsonUtility.ToJson(data);
        // save JSON to file
        File.WriteAllText(Application.persistentDataPath + fileName, json);
        
        Debug.Log("Game Saved!");

        return data;
    }
    /* Start new game */
    public GameDataScript StartNewGame()
    {
        // create an Empty Game Stats object
        GameDataScript data = new GameDataScript();
    
        SaveGame(data);

        return LoadGame();
    }

    public GameDataScript LoadGame()
    {
        // check if there is saved data
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            // get data from file
            string json = File.ReadAllText(Application.persistentDataPath + fileName);
            // parse JSON to obj
            GameDataScript data = JsonUtility.FromJson<GameDataScript>(json);
            Debug.Log("Game Loaded!");

            return data;
        }
        else
        {
            Debug.Log("No save file found!");

            // create an Empty Game Stats object
            GameDataScript data = new GameDataScript();
            
            SaveGame(data);

            return data;
        }
    }
}
