using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneScript : MonoBehaviour
{
    [Header("Name of next scene to load")]
    public string nextScene;

    private GameMasterScript gm;

    public void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMasterScript>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // updates the current scene with next scene and saves game to local storage
            gm.UpdateCurrentScene(nextScene);
            gm.SaveGame();

            SceneManager.LoadScene(nextScene);
        }
    }

}
