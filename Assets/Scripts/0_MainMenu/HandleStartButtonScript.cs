using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HandleStartButtonScript : MonoBehaviour, IPointerDownHandler
{
    private GameMasterScript gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMasterScript>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Start pressed");

        SceneManager.LoadScene(gm.StartNewGame());
    }
}
