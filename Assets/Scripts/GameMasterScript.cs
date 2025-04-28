using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    // instance of current Game Master
    public static GameMasterScript Instance;

    // allows to manipulate saved data 
    private SaveGameManagerScript sgm;
    // current saved data
    private GameDataScript data;

    [Header("Game States")]
    public string currentScene;
    public int lives;
    public int coins;

    // in awake we save game object between scenes 
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

    void Start()
    {
        // get currently saved data
        sgm = ScriptableObject.CreateInstance<SaveGameManagerScript>();
        data = GetGameData();

        // update Game Master data
        currentScene = data.currentScene;
        lives = data.lives;
        coins = data.coins;
    }

    // get currently saved data
    public GameDataScript GetGameData() { return sgm.LoadGame(); }

    // starts new game and returns the first scene
    public string StartNewGame()
    {
        // create default data obj
        GameDataScript data = new GameDataScript();
        // save to local storage
        sgm.SaveGame(data);

        // update Game Master states
        currentScene = data.currentScene;
        lives = data.lives;
        coins = data.coins;

        return currentScene;
    }

    public void UpdateCurrentScene(string scene) { currentScene = scene; }

    // save Game Master obj game stats to local storage
    public void SaveGame()
    {
        data.currentScene = currentScene;
        data.lives = lives;
        data.coins = coins;

        sgm.SaveGame(data);
    }

    /* Getters */
    public string GetCurrentScene() { return currentScene; }
    public int GetCoins() { return coins; }
    public int GetLives() { return lives; }

    /* Setters */

    public int AddCoins(int n) { 
        coins += n;
        return coins; 
    }

    public int SubtractCoins(int n)
    {
        coins -= n;
        return coins;
    }
    public int AddLives(int n)
    {
        lives += n;
        return lives;
    }
    public int SubtractLives(int n)
    {
        lives -= n;
        return lives;
    }
}
